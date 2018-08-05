using System;
using System.Reflection;
using Xunit;
using Sane;
using Sane.Test.Utils;
using Xunit.Abstractions;

namespace Sane.Test.Sane
{
    
    public class CompilerTest
    {
        private readonly ITestOutputHelper output;

        public CompilerTest(ITestOutputHelper output)
        {
            this.output = output;
        }
        
        [Fact]        
        public void DeclareConst()
        {
            var subject = new Compiler();
            const string sane = @"
            module A
                let x = 1
                let y = ""dupa """"dupa"""" ""
            end";

            const string js = @"A = {};
A.x = 1;
A.y = ""dupa \""dupa\"" "";
";
            ScriptAssert.Equal(js, "", subject.Translate(sane));
        }
//        
//        [Fact]
//        public void DeclareOperations()
//        {
//            var subject = new Compiler();
//            const string sane = @"
//            module A
//                let x = 1
//                let y = (x + 1) * 2 - 3 / 4    
//            end";
//
//            const string js = @"A = {};
//A.x = 1;
//A.y = (A.x + 1) * 2 - 3 / 4;
//";
//            ScriptAssert.Equal(js, "", subject.Translate(sane));
//        }
//        
//        
//        [Fact]
//        public void DeclareFunctions()
//        {
//            var subject = new Compiler();
//            const string sane = @"
//            module A
//                let x = (a) -> a * 2
//            end";
//
//            const string js = @"A = {};
//A.x = function(a) {
//return a * 2;
//};
//";
//            ScriptAssert.Equal(js, "", subject.Translate(sane));
//        }
//
//        [Fact]
//        public void CallFunction()
//        {
//            var subject = new Compiler();
//            const string sane = @"
//            module A
//                let x = (a) -> a * 2
//                let y = (b) -> x(b + 3)
//                let z = y(2)
//                let w = (a b) -> (a) -> a + b + y(b * 2)
//            end";
//
//            const string js = @"A = {};
//A.x = function(a) {
//return a * 2;
//};
//A.y = function(b) {
//return A.x(b + 3);
//};
//A.z = A.y(2);
//A.w = function(a, b) {
//return function(a) {
//return a + b + A.y(b * 2);
//};
//};
//";
//            output.WriteLine("CallFunction");
//            var result = subject.Translate(sane);
//            ScriptAssert.Equal(js, "", result);
//        }
//
//        [Fact]
//        public void CantFindId()
//        {
//            var subject = new Compiler();
//            const string sane = @"
//            module A
//                let x = () -> b
//            end
//";
//            var result = subject.Translate(sane);
//        }
//
//        public void DeclareRecursive()
//        {
//                        
//            // atrybut "rec" może mówić, by zapamiętać ID i użyć wewnątrz declaracji
//            var t = @"
//            rec type B where
//                a : String
//                b : B
//            end
//
//            rec let y = (a) -> cond
//                a > 10 -> ""stop""
//                _ -> y(a+1)
//            end
//            
//                 
//";
//            // Zastanowic sie czy taka składnia jest fajna.
//            const string sane = @"
//            A = module (x w) where
//                let x = 1
//                let x = 2
//                let w = func (a b c) -> result where
//                    let result = a + d where
//                        let d = b + c
//                    end
//                end 
//            end";
//        }
//        
//        
//        public void DeclareUnion() {
//            var subject = new Compiler();
//            var sane = @"
//            module A =
//                type Maybe T = union {
//                    Value : T
//                    None
//                }
//
//                x : Maybe String
//                x = Maybe.Value ""something""
//
//                default : Maybe String -> String -> String
//                default maybe defValue = {
//                    match maybe {
//                        with Maybe.Value as value -> value
//                        with Maybe.None -> defValue
//                    }
//                }
//
//                defaultNothing maybe = default maybe ""nothing""
//            }
//            ";
//        }
//
//        public void DeclareFunction()
//        {
//            var subject = new Compiler();
//            var sane = @"
//            module A = 
//              aPlusB : Integer -> Integer -> Integer
//              aPlusB a b = a + b
//
//              aPlusB1 : {a : Integer, b : Integer} -> Integer
//              aPlusB1 {a, b} = a + b
//
//              type AAndB = {
//                  a : Integer,
//                  b : Integer
//              }
//
//              type Maybe(T) = union {
//                  some : T,
//                  none : Unit
//              }
//
//              type AAndBOther (AAndB, CAndD) = {
//                  a1 = AAndB.a,
//                  a2 = AAndB.b,
//                  a3 = CAndD.c,
//                  a4 = CAndD.d,
//              }
//
//              aPlusB2 : AAndB -> Integer
//              aPlusB2 s = (s . a) + (s . b)
//            ";
//
//            var js = @"
//            A = {};
//            A.aPlusB = function(a, b) {
//                return a + b;
//            };
//            ";
////            Assert.Equal(subject.Translate(sane), js);
//        }
    }
}
