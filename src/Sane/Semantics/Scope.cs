using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace Sane.Semantics
{
    public class Scope
    {                
        private readonly IDictionary<string, Symbol<BaseNode>> _variables = new Dictionary<string, Symbol<BaseNode>>();
        public Scope Parent { get; }
        
        public BaseNode Node { get; }
        
        public string Name { get; }

        public Scope(BaseNode node, Scope parent = null)
        {
            Parent = parent;
            Node = node;
            Name = (node as IScopeProviding)?.ScopeName;
        }

        public Symbol<BaseNode> AddVariable(string name, BaseNode node)
        {
            var symbol = new Symbol<BaseNode>(name, node, this);
            _variables.Add(name, symbol);
            return symbol;
        }

        public Symbol<BaseNode> FindVariable(string name)
        {
            if (_variables.ContainsKey(name))
            {
                return _variables[name]; 
            }

            return Parent?.FindVariable(name);
        }

        public Symbol<BaseNode> FindVariableInCurrent(string name)
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

        public IEnumerable<Scope> Ancestry(bool includingThis = false)
        {
            var scope = includingThis ? this : Parent;
            while (scope != null)
            {
                yield return scope;
                scope = scope.Parent;
            }
        }
    }
}