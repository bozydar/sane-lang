using System.IO;
using Sane.Cli;
using Xunit;

namespace Sane.Test.Sane.Cli
{
    public class OutputTest
    {
        [Fact]        
        public void DeclareConst()
        {
            File.Delete("output.js");
            
            var translationResult = new TranslationResult("Output", "Errors");
            var subject = new Output(translationResult, "output.js");
            
            subject.Proceed();
            
            Assert.Equal("Output", File.ReadAllText("output.js"));
        }
    }
}