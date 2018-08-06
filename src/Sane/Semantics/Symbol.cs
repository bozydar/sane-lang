using System.Linq;

namespace Sane.Semantics
{
    public class Symbol<TNodeType> where TNodeType : BaseNode
    {
        public string Name { get; }
        public TNodeType Node { get; }
        public Scope Scope { get; }
        
        public Symbol(string name, TNodeType node, Scope scope)
        {
            Name = name;
            Node = node;
            Scope = scope;
        }

        public string AbsoluteName()
        {
            if (Node is ParamNode)
            {
                return Name;
            }
            var modulePath = Scope.Ancestry(true)
                .Where(scope => scope.Name != null)
                .Select(scope => scope.Name)
                .Reverse()
                .ToList();
            modulePath.Add(Name);
            return string.Join(".", modulePath);
        }
    }
}