using System;
using System.Collections.Generic;
using System.Linq;
using Sane.Semantics;

namespace Sane
{
    public class JsOutputVisitor : AstVisitor<string>
    {
        public class InstanceConfig
        {
            public bool EmptyModuleWarning { get; set; } = true;
        }

        public JsOutputVisitor(Errors errorsSink = null, InstanceConfig config = null) 
            : base(errorsSink)
        {
            Config = config ?? new InstanceConfig();
        }

        public InstanceConfig Config { get; }
        
        private Scope Scope = new Scope(null);
        
        public override string Visit(ModuleNode node)
        {
            if (node.Lets.Count == 0 && Config.EmptyModuleWarning)
            {
                AddError(Error.ErrorLevel.Warning, node, $"Module `{node.Id}` is empty.");
            }
            Scope = Scope.CreateChildScope(node);
            var lets = node.Lets.Aggregate("", (acc, let) => acc + Visit(let) + ";");            
            var result = $"{node.Id} = {{}};\n{lets}\n";
            Scope = Scope.Parent;
            return result;
        }

        public override string Visit(LetNode node)
        {            
            var symbol = Scope.FindVariableInCurrent(node.Id);
            if (symbol != null)
            {
                AddError(Error.ErrorLevel.Error, node, $"Variable `{node.Id}` already exists.");
            }
            symbol = Scope.AddVariable(node.Id, node);
            var left = symbol.AbsoluteName();

            var right = Visit(node.Expr);
            if (right == null)
            {
                AddError(Error.ErrorLevel.Error, node, $"Variable `{node.Id}` has no value defined.");
            }
            return $"{left} = {right}";
        }

        public override string Visit(ExprNode node)
        {
            dynamic arg = node;
            return Visit(arg);            
        }

        public override string Visit(CallNode node)
        {
            throw new System.NotImplementedException();
        }

        public override string Visit(StringNode node)
        {
            return $"\"{node.Value}\"";
        }

        public override string Visit(NumericNode node)
        {
            return $"{node.Value}";
        }

        public override string Visit(ListNode node)
        {
            throw new System.NotImplementedException();
        }

        public override string Visit(ExternalNode node)
        {
            throw new System.NotImplementedException();
        }

        public override string Visit(BinaryExprNode node)
        {
            var left = Visit(node.Left);
            var right = Visit(node.Right);
            var op = node.Id;
            return $"{left} {op} {right}";
        }

        public override string Visit(FuncNode node)
        {
            var parameters = string.Join(", ", node.Parameters.Select(param => param.Id));            
            Scope = Scope.CreateChildScope(node);
            foreach (var param in node.Parameters)
            {
                Scope.AddVariable(param.Id, param);
            }
            var body = Visit(node.Body);
            
            var result = $"function ({parameters}) {{\nreturn {body};\n}}";
            Scope = Scope.Parent;
            return result;
        }

        public override string Visit(ReferenceNode node)
        {
            var symbol = Scope.FindVariable(node.Id);
            if (symbol == null)
            {
                AddError(Error.ErrorLevel.Error, node, $"Variable `{node.Id}` doesn't exist.");
            }
            
            return symbol.AbsoluteName();
        }

        public override string Visit(LetInNode node)
        {
            Scope = Scope.CreateChildScope(node);
            
            var lets = node.Lets
                .Select(let => $"var {Visit(let)};\n")
                .ToArray();
            var letsExprs = string.Join("", lets);
            var body = Visit(node.Body);            
            var result = $"function () {{\n{letsExprs}\nreturn {body};\n}}()"; 
            
            Scope = Scope.Parent;
            
            return result;
        }
    }
}