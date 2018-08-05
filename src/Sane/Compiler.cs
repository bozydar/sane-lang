using System;
using System.Linq;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using Sane.Grammar;
using Sane.Semantics;

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
            var module = parser.module();

            var errorsSink = new Errors();
            var astBuilder = new AstBuilder(errorsSink);
            var jsOutputVisitor = new JsOutputVisitor(errorsSink);
            
            var ast = astBuilder.Visit(module) as ModuleNode;
            var output = jsOutputVisitor.Visit(ast);

            var errors = errorsSink.GetErrorsString();
            return new TranslationResult(output, errors);
        }
    }
}
