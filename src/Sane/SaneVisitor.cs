using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using Sane.Grammar;

namespace Sane {
    public class SaneVisitor : SaneBaseVisitor<string>
    {
        private readonly Stack<SaneParser.ModuleContext> _moduleContexts = new Stack<SaneParser.ModuleContext>();
        private readonly Stack<SaneParser.FunctionContext> _functionContexts = new Stack<SaneParser.FunctionContext>();

        public override string VisitModule([NotNull] SaneParser.ModuleContext context)
        {
            Console.WriteLine("--- VisitModule");
            var moduleName = context.moduleName.Text;
            Console.WriteLine($"module: {moduleName}");
            // TODO It has only push but should have pop too. Maybe listener instead of visitor
            _moduleContexts.Push(context);           

            var visits = string.Join("", context.let().Select(Visit));
//            var visits = VisitChildren(context);
            return $"{moduleName} = {{}};\n{visits}";
        }

        public override string VisitParenthesisExp(SaneParser.ParenthesisExpContext context)
        {
            var expression = Visit(context.expression());
            return $"({expression})";
        }

        public override string VisitFunction(SaneParser.FunctionContext context)
        {
            var parameters = string.Join(", ", context.parameter().Select(parameter => parameter.GetText()));
            _functionContexts.Push(context);
            var body = Visit(context.body);
            return $"function({parameters}) {{\nreturn {body};\n}}";
        }

        public override string VisitCall(SaneParser.CallContext context)
        {
            var expressions = context.expression().Select(Visit);            
            var intoParams = string.Join(", ", expressions);
            var binding = FindBiding(context.funcName.Text); 
            return $"{binding}({intoParams})";
        }

        public override string VisitMulDivExp(SaneParser.MulDivExpContext context)
        {
            var left = Visit(context.left);
            var right = Visit(context.right);
            var op = context.operation.Text;
            return $"{left} {op} {right}";
        }

        public override string VisitAddSubExp(SaneParser.AddSubExpContext context)
        {
            var left = Visit(context.left);
            var right = Visit(context.right);
            var op = context.operation.Text;
            return $"{left} {op} {right}";
        }

        public override string VisitDeclaration([NotNull] SaneParser.DeclarationContext context)
        {
            throw new NotImplementedException();
        }

        public override string VisitErrorNode(IErrorNode node)
        {
            Console.WriteLine($"VisitErrorNode {node.GetText()}");
            Console.WriteLine($"VisitErrorNode {node.Symbol}");
            return base.VisitErrorNode(node);
        }

        public override string VisitLet([NotNull] SaneParser.LetContext context)
        {
            Console.WriteLine("--- VisitLet");
            var name = context.bindingName.Text;
            var expr = VisitChildren(context);
            return $"{CurrentModule.moduleName.Text}.{name} = {expr};\n";
        }

        public override string VisitNumericAtomExp(SaneParser.NumericAtomExpContext context)
        {
            Console.WriteLine("--- VisitNumericAtomExp");
            return context.value.Text;
        }

        public override string VisitTerminal(ITerminalNode node)
        {            
            var value = node.Symbol.Text;
            return FindBiding(value);
        }

        private string FindBiding(string id)
        {
            foreach (var functionContext in _functionContexts)
            {
                if (functionContext.parameter().Any(parameter => parameter.GetText() == id))
                {
                    return id;
                }
            }
            // TODO implement inserting binding names to module. If id not found output error "Error 1: Symbol not found"
            return $"{CurrentModule.moduleName.Text}.{id}";
        }

        private SaneParser.ModuleContext CurrentModule => _moduleContexts.Peek();
        private SaneParser.FunctionContext CurrentFunction => _functionContexts.Peek();
    }
}