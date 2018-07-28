using System.Collections.Generic;

namespace Sane.Semantics
{
    public class Scope
    {                
        private readonly IDictionary<string, Binding> _bindings = new Dictionary<string, Binding>();
        private Scope _parent;
                
        public Scope(Scope parent = null)
        {
            _parent = parent;
        }
        

        public void AddSymbol(Binding binding)
        {
            _bindings.Add(binding.Name, binding);
        }

        public Binding FindSymbol(string name)
        {
            if (_bindings.ContainsKey(name))
            {
                return _bindings[name]; 
            }

            return _parent?.FindSymbol(name);
        }

        public Scope CreateChildScope()
        {
            return new Scope(this);
        }
    }
}