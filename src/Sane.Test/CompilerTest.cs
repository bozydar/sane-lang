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
            const string sane = @"
            module A
                let x = 1
            end";

            const string js = @"A = {};
A.x = 1;
";
            ScriptAssert.Equal(js, subject.Translate(sane));
        }
        
        [Fact]
        public void DeclareOperations()
        {
            var subject = new Compiler();
            const string sane = @"
            module A
                let x = 1
                let y = (x + 1) * 2 - 3 / 4    
            end";

            const string js = @"A = {};
A.x = 1;
A.y = (A.x + 1) * 2 - 3 / 4;
";
            ScriptAssert.Equal(js, subject.Translate(sane));
        }

        [Fact]
        public void Functions()
        {
            var subject = new Compiler();
            const string sane = @"
            module A
                let x a = a + 1
                let y = x 2    
                let y = z where 
                    let z = x + 2
            end";

            const string js = @"A = {};
A.x = function(a) {
return a + 1;
};
A.y = A.x(2);
";
            ScriptAssert.Equal(js, subject.Translate(sane));
        }

        public void DeclareUnion() {
            var subject = new Compiler();
            var sane = @"
            module A =
                type Maybe T = union {
                    Value : T
                    None
                }

                x : Maybe String
                x = Maybe.Value ""something""

                default : Maybe String -> String -> String
                default maybe defValue = {
                    match maybe {
                        with Maybe.Value as value -> value
                        with Maybe.None -> defValue
                    }
                }

                defaultNothing maybe = default maybe ""nothing""
            }
            ";
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

              type Maybe(T) = union {
                  some : T,
                  none : Unit
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
