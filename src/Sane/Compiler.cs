using System;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using Sane.Grammar;

namespace Sane
{
    public class Compiler
    {
        public Compiler() {

        }

        public string Translate(string input)
        {
            AntlrInputStream inputStream = new AntlrInputStream(input);
            var lexer = new SaneLexer(inputStream);
            var commonTokenStream = new CommonTokenStream(lexer);
            var parser = new SaneParser(commonTokenStream);
            var visitor = new SaneVisitor();            
            var walker = new ParseTreeWalker();
            var module = parser.module();
            Console.WriteLine(module);
            return visitor.Visit(module);
        }
    }
}
