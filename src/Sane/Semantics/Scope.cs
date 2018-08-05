using System;
using System.Collections.Generic;

namespace Sane.Semantics
{
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
}