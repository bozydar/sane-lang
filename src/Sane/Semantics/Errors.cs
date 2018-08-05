using System.Collections.Generic;
using System.Linq;
using Antlr4.Runtime;

namespace Sane.Semantics
{
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
}