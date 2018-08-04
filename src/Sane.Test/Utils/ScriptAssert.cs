using System.Text.RegularExpressions;
using Xunit;

namespace Sane.Test.Utils
{
    public static class ScriptAssert
    {    
        public static void Equal(string expected, string actual)
        {
            expected = NormalizeEol(expected);
            actual = NormalizeEol(actual);
            Assert.Equal(expected, actual);
        }

        public static void EqualOutput(string expectedOutput, TranslationResult translationResult)
        {
            Equal(expectedOutput, translationResult.Output);            
        }
        
        public static void Equal(string expectedOutput, string expectedErrors, TranslationResult translationResult)
        {
            Equal(expectedOutput, translationResult.Output);
            Equal(expectedErrors, translationResult.Errors);
        }
        
        public static void EqualErrors(string expectedErrors, TranslationResult translationResult)
        {
            Equal(expectedErrors, translationResult.Errors);            
        }

        private static readonly Regex CrCn = new Regex("(\r)?\n");
        private static string NormalizeEol(string value)
        {
            return CrCn.Replace(value, "");
        }
    }
}