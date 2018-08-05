using System;
using System.Collections.Generic;

namespace Sane.Semantics
{
    public class Scope
    {                
        private readonly IDictionary<string, Symbol<BaseNode>> _variables = new Dictionary<string, Symbol<BaseNode>>();
        private Scope _parent;
        public Scope Parent => _parent;
        
        private BaseNode _node;
        public BaseNode Node => _node;

        public Scope(BaseNode node, Scope parent = null)
        {
            _parent = parent;
            _node = node;
        }

        public void AddVariable(string name, BaseNode expression)
        {
            _variables.Add(name, new Symbol<BaseNode>(name, expression));
        }

        public Symbol<BaseNode> FindVariable(string name)
        {
            if (_variables.ContainsKey(name))
            {
                return _variables[name]; 
            }

            return _parent?.FindVariable(name);
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
    }
}