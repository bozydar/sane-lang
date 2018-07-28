using System;
using System.Linq;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using Sane.Grammar;

namespace Sane
{
    public class Compiler
    {
        public Compiler() {

        }

        public TranslationResult Translate(string input)
        {
            AntlrInputStream inputStream = new AntlrInputStream(input);
            var lexer = new SaneLexer(inputStream);
            var commonTokenStream = new CommonTokenStream(lexer);
            var parser = new SaneParser(commonTokenStream);
            var visitor = new SaneVisitor();            
            var walker = new ParseTreeWalker();
            var module = parser.module();

            var output = visitor.Visit(module);
            var errors = string.Join("\n", visitor.Errors);
            return new TranslationResult(output, errors);
        }
    }
}
