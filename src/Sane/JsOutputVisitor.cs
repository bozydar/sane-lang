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
            _config = config ?? new InstanceConfig();
        }

        private InstanceConfig _config;
        public InstanceConfig Config => _config;
        
        protected Scope _scope = new Scope(null);
        
        public override string Visit(ModuleNode node)
        {
            if (node.Lets.Count == 0 && Config.EmptyModuleWarning)
            {
                AddError(Error.ErrorLevel.Warning, node, $"Module `{node.Id}` is empty.");
            }
            _scope = _scope.CreateChildScope(node);
            var lets = node.Lets.Aggregate("", (acc, let) => acc + Visit(let) + ";");            
            return $"{node.Id} = {{}};\n{lets}\n";
        }

        public override string Visit(LetNode node)
        {            
            var symbol = _scope.FindVariableInCurrent(node.Name);
            if (symbol != null)
            {
                AddError(Error.ErrorLevel.Error, node, $"Variable `{node.Name}` already exists.");
            }
            _scope.AddVariable(node.Name, node.Expr);
            var left = VariablePath(node.Name);
            var right = Visit(node.Expr);
            if (right == null)
            {
                AddError(Error.ErrorLevel.Error, node, $"Variable `{node.Name}` has no value defined.");
            }
            Console.WriteLine("HERE");
            return $"{left} = {right}";
        }

        private string VariablePath(string name)
        {            
            var result = new List<string>
            {
                name
            };
            
            var scope = _scope;
            while (scope != null)
            {
                Console.WriteLine("node");
                Console.WriteLine(scope.Node);
                if (scope.Node is ModuleNode node)
                {
                    result.Add(node.Id);
                }

                scope = scope.Parent;
            }

            result.Reverse();
            return string.Join(".", result);
        }

        public override string Visit(ExprNode node)
        {
            dynamic arg = node;
            Console.WriteLine("arg");
            Console.WriteLine(arg);
            Console.WriteLine("-----");
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
            var body = Visit(node.Body);
            var parameters = string.Join(", ", node.Parameters);
            return $"function ({parameters}) {{\nreturn {body};\n}}";
        }
    }
}