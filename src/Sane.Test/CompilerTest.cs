using System;
using Xunit;
using Sane;

namespace Sane.Test
{
    public class CompilerTest
    {
        [Fact]
        public void DeclareConst()
        {
            var subject = new Compiler();
            var sane = @"
            module A = 
              x : Integer
              x = 1
            ";

            var js = @"
            A = {};
            A.x = 1;
            ";
            Assert.Equal(subject.Translate(sane), js);
        }

        public void DeclareFunction()
        {
            var subject = new Compiler();
            var sane = @"
            module A = 
              aPlusB : Integer -> Integer -> Integer
              aPlusB a b = a + b

              aPlusB1 : {a : Integer, b : Integer} -> Integer
              aPlusB1 {a, b} = a + b

              type AAndB = {
                  a : Integer,
                  b : Integer
              }

              type Maybe T = {
                  Some : T,
                  None
              }

              type AAndBOther (AAndB, CAndD) = {
                  a1 = AAndB.a,
                  a2 = AAndB.b,
                  a3 = CAndD.c,
                  a4 = CAndD.d,
              }

              aPlusB2 : AAndB -> Integer
              aPlusB2 s = (s . a) + (s . b)
            ";

            var js = @"
            A = {};
            A.aPlusB = function(a, b) {
                return a + b;
            };
            ";
            Assert.Equal(subject.Translate(sane), js);
        }
    }
}
