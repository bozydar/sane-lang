using System;
using System.Text.RegularExpressions;
using Xunit;
using Xunit.Sdk;

namespace Sane.Test
{
    public static class ScriptAssert
    {    
        public static void Equal(string expected, string actual)
        {
            expected = NormalizeEol(expected);
            actual = NormalizeEol(actual);
            Assert.Equal(expected, actual);
        }

        private static readonly Regex CrCn = new Regex("\r\n");
        private static string NormalizeEol(string value)
        {
            return CrCn.Replace(value, "\n");
        }
    }
}