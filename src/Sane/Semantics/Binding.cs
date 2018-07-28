using Antlr4.Runtime;

namespace Sane.Semantics
{
    public class Binding
    {
        private string _name;
        public string Name => _name;
        
        private readonly IToken _token;
        public IToken Token => _token;
        
        public Binding(string name, IToken token)
        {
            _name = name;
            _token = token;
        }
    }
}