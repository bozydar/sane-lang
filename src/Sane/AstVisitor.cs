using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Xml.Schema;
using Antlr4.Runtime;
using Sane.Semantics;

namespace Sane
{
    public class Error
    {
        public enum ErrorLevel
        {
            Hint,
            Warning,
            Error
        }
        public IToken Token { get; set; }
        public ErrorLevel Level { get; set; }
        public string Message { get; set; }
    }
    
    public class Symbol<TNodeType> where TNodeType : BaseNode
    {
        private string _name;
        public string Name => _name;
        
        private readonly TNodeType _node;
        public TNodeType Node => _node;
        
        public Symbol(string name, TNodeType node)
        {
            _name = name;
            _node = node;
        }
    }
    
    public class Scope
    {                
        private readonly IDictionary<string, Symbol<ExprNode>> _variables = new Dictionary<string, Symbol<ExprNode>>();
        private Scope _parent;
        public Scope Parent => _parent;
        
        private BaseNode _node;
        public BaseNode Node => _node;

        public Scope(BaseNode node, Scope parent = null)
        {
            _parent = parent;
            _node = node;
        }

        public void AddVariable(string name, ExprNode expression)
        {
            _variables.Add(name, new Symbol<ExprNode>(name, expression));
        }

        public Symbol<ExprNode> FindVariable(string name)
        {
            if (_variables.ContainsKey(name))
            {
                return _variables[name]; 
            }

            return _parent?.FindVariable(name);
        }

        public Symbol<ExprNode> FindVariableInCurrent(string name)
        {
            if (_variables.ContainsKey(name))
            {
                return _variables[name]; 
            }

            return null;
        }

        public Scope CreateChildScope(BaseNode node)
        {
            Console.WriteLine($"new scope for {node}");
            return new Scope(node, this);
        }
    }

    public class CompilationException : Exception
    {
        private readonly Errors _errors;
        public Errors Errors => _errors;

        public CompilationException(Errors errors)
        {
            _errors = errors;
        }
    }

    public class Errors : List<Error>
    {
        public string GetErrorsString()
        {
            var errors = this.Select(error => $"{error.Level}:{FormatToken(error.Token)}: {error.Message}");
            return string.Join("\n", errors);
        }

        protected string FormatToken(IToken token)
        {
            return token == null ? "N/A" : $"{token.Line}:{token.Column}";
        }   
    }
    
    public abstract class AstVisitor<T>
    {
        public Errors Errors { get; } = new Errors();
        public abstract T Visit(ModuleNode node);
        public abstract T Visit(LetNode node);
        public abstract T Visit(ExprNode node);
        public abstract T Visit(CallNode node);
        public abstract T Visit(StringNode node);
        public abstract T Visit(NumericNode node);
        public abstract T Visit(ListNode node);
        public abstract T Visit(ExternalNode node);
        public abstract T Visit(BinaryExprNode node); 
        public abstract T Visit(FuncNode node); 

        public void AddError(Error.ErrorLevel level, BaseNode node, string message)
        {
            Errors.Add(new Error
            {
                Level = level,
                Token = node.Token,
                Message = message
            });
            if (level == Error.ErrorLevel.Error)
            {
                throw new CompilationException(Errors);
            }
        }
    }

    public class JsOutputVisitor : AstVisitor<string>
    {
        public class InstanceConfig
        {
            public bool EmptyModuleWarning { get; set; } = true;
        }

        public JsOutputVisitor(InstanceConfig config = null)
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