using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Net.Security;
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
                Token = context.moduleName 
            };
        }

        public override BaseNode VisitLet(SaneParser.LetContext context)
        {
            var variableName = context.bindingName.Text;
            var expr = VisitChildren(context) as ExprNode;
            return new LetNode
            {
                Id = variableName,
                Expr = expr,
                Token = context.bindingName
            };
        }

        public override BaseNode VisitParenthesisExp(SaneParser.ParenthesisExpContext context)
        {
            return VisitChildren(context);            
        }

        public override BaseNode VisitAddSubExp(SaneParser.AddSubExpContext context)
        {
            var left =  VisitChildren(context.left) as ExprNode;
            var right =  VisitChildren(context.right) as ExprNode;
            return new BinaryExprNode
            {
                Id = context.operation.Text,
                Left = left,
                Right = right,
                Token = context.operation
            };
        }

        public override BaseNode VisitMulDivExp(SaneParser.MulDivExpContext context)
        {
            var left =  VisitChildren(context.left) as ExprNode;
            var right =  VisitChildren(context.right) as ExprNode;
            return new BinaryExprNode
            {
                Id = context.operation.Text,
                Left = left,
                Right = right,
                Token = context.operation
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
                Token = context.value
            };
        }

        public override BaseNode VisitStringAtomExp(SaneParser.StringAtomExpContext context)
        {
            var value = context.value.Text.Trim('"').Replace("\"\"", "\\\"");
            return new StringNode
            {
                Value = value,
                Token = context.value
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