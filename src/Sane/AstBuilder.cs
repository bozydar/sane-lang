using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Net.Security;
using System.Reflection.Metadata.Ecma335;
using System.Text.RegularExpressions;
using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using Sane.Grammar;
using Sane.Semantics;

namespace Sane {
    public class AstBuilder : SaneBaseVisitor<BaseNode>
    {
        public Errors ErrorsSink { get; }

        public AstBuilder(Errors errorsSink = null)
        {
            ErrorsSink = errorsSink ?? new Errors();
        }

        public override BaseNode VisitModule(SaneParser.ModuleContext context)
        {
            var id = context.moduleName.Text;
            var lets = context.let()
                .Select(VisitLet)
                .Cast<LetNode>()
                .ToList();
            return new ModuleNode
            {
                Id = id,
                Lets = lets,
                Token = context.Start 
            };
        }

        public override BaseNode VisitLet(SaneParser.LetContext context)
        {
            var variableName = context.bindingName.Text;
            var expr = Visit(context.expression()) as ExprNode;
            return new LetNode
            {
                Id = variableName,
                Expr = expr,
                Token = context.Start
            };
        }

        public override BaseNode VisitLetsInExp(SaneParser.LetsInExpContext context)
        {
            var expr = Visit(context.body) as ExprNode;
            var lets = context.let()
                .Select(VisitLet)
                .Cast<LetNode>()
                .ToList();
            return new LetInNode
            {
                Lets = lets,
                Body = expr,
                Token = context.Start
            };
        }

        public override BaseNode VisitExternalNode(SaneParser.ExternalNodeContext context)
        {
            // cut 3 first and last graves
            var body = context.body.Text
                .Substring(3, context.body.Text.Length - 6)
                .Trim()
                .Replace("\\`", "`");
            return new ExternalNode
            {
                Body = body,
                Token = context.Start
            };
        }

        public override BaseNode VisitParenthesisExp(SaneParser.ParenthesisExpContext context)
        {
            return Visit(context.body);            
        }

        public override BaseNode VisitAddSubExp(SaneParser.AddSubExpContext context)
        {
            var left =  Visit(context.left) as ExprNode;
            var right =  Visit(context.right) as ExprNode;
            if (left == null)
            {
                AddError(Error.ErrorLevel.Error, context.Start, "Left expression not detected");
            }
            if (right == null)
            {
                AddError(Error.ErrorLevel.Error, context.Start, "Right expression not detected");
            }
            return new BinaryExprNode
            {
                Id = context.operation.Text,
                Left = left,
                Right = right,
                Token = context.Start
            };
        }

        public override BaseNode VisitMulDivExp(SaneParser.MulDivExpContext context)
        {
            var left =  Visit(context.left) as ExprNode;
            var right =  Visit(context.right) as ExprNode;
            return new BinaryExprNode
            {
                Id = context.operation.Text,
                Left = left,
                Right = right,
                Token = context.Start
            };
        }

        public override BaseNode VisitParameter(SaneParser.ParameterContext context)
        {
            return new ParamNode
            {
                Id = context.GetText(),
                Token = context.Start
            };
        }

        public override BaseNode VisitFunction(SaneParser.FunctionContext context)
        {
            var parameters = context.parameter()
                .Select(VisitParameter)
                .Cast<ParamNode>()
                .ToList();
            var body = Visit(context.body) as ExprNode;
            return new FuncNode
            {
                Parameters = parameters,
                Body = body
            };
        }

        public override BaseNode VisitCall(SaneParser.CallContext context)
        {
            var parameters = context.expression().Skip(1)
                .Select(Visit)
                .Cast<ExprNode>()
                .ToList();
            var expression = (ExprNode)Visit(context.callable);             
            return new CallNode
            {
                Parameters = parameters,
                Expr = expression
            };
        }

        public override BaseNode VisitNumericAtomExp(SaneParser.NumericAtomExpContext context)
        {
            if (!decimal.TryParse(context.value.Text, out var value))
            {
                AddError(Error.ErrorLevel.Error, context.value, $"Can't convert `{context.value.Text}` to decimal.");
            }

            return new NumericNode
            {
                Value = value,
                Token = context.Start
            };
        }

        public override BaseNode VisitArrayExp(SaneParser.ArrayExpContext context)
        {
            var exprs = context.expression()
                .Select(Visit)
                .Cast<ExprNode>()
                .ToList();
            return new ArrayNode
            {
                Exprs = exprs,
                Token = context.Start
            };
        }

        public override BaseNode VisitStringAtomExp(SaneParser.StringAtomExpContext context)
        {
            var value = context.value.Text.Trim('"').Replace("\"\"", "\\\"");
            return new StringNode
            {
                Value = value,
                Token = context.Start
            };
        }

        public override BaseNode VisitIdAtomExp(SaneParser.IdAtomExpContext context)
        {
            var id = context.id.Text;
            return new ReferenceNode
            {
                Id = id,
                Token = context.Start
            };
        }

        private void AddError(Error.ErrorLevel level, IToken token, string message)
        {
            ErrorsSink.Add(new Error
            {
                Level = level,
                Token = token,
                Message = message
            });
            if (level == Error.ErrorLevel.Error)
            {
                throw new CompilationException(ErrorsSink);
            }
        }
    }
}