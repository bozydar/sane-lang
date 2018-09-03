using Xunit;

namespace Sane.Test.Sane
{
    public class AstBuilderTest
    {
        [Fact]
        public void DeclareConst()
        {
            var subject = new AstBuilder();
            const string sane = @"
            module A
                x = 1
            end";

            const string js = @"A = {};
A.x = 1;
";
//            ScriptAssert.Equal(js, "", subject.Translate(sane));
        }
    }
}