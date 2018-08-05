using Antlr4.Runtime;

namespace Sane.Semantics
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
}