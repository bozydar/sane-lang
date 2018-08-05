namespace Sane.Semantics
{
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
}