namespace Sane.Semantics
{
    public class ModuleScope : Scope
    {
        private string _name;
        public string Name => _name;
        
        public ModuleScope(string name, Scope parent = null) : base(parent)
        {
            _name = name;            
        }
    }
}