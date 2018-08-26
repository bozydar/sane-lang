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
                x = 1
                y = ""dupa """"dupa"""" ""
            end";

            const string js = @"A = {};
A.x = 1;
A.y = ""dupa \""dupa\"" "";
";
            ScriptAssert.Equal(js, "", subject.Translate(sane));
        }
        
        [Fact]
        public void DeclareLetIn()
        {
            var subject = new Compiler();
            const string sane = @"
            module A
                x = 
                    let
                        a = 1
                        b = 2
                    in
                        a + b
                    end
            end";

            const string js = @"A = {};
A.x = function () {
var a = 1;
var b = 2;
return (a + b);
}();
";
            ScriptAssert.Equal(js, "", subject.Translate(sane));
        }
        
        [Fact]
        public void DeclareOperations()
        {
            var subject = new Compiler();
            const string sane = @"
            module A
                let x = 1
                let y = x + 1 * 2 - 3 / 4    
                let z = (x + 1) * (2 - 3) / 4    
            end";

            const string js = @"A = {};
A.x = 1;
A.y = ((A.x + (1 * 2)) - (3 / 4));
A.z = (((A.x + 1) * (2 - 3)) / 4);
";
            ScriptAssert.Equal(js, "", subject.Translate(sane));
        }
        
        
        [Fact]
        public void DeclareFunctions()
        {
            var subject = new Compiler();
            const string sane = @"
            module A
                x = (a) -> a * 2
            end";

            const string js = @"A = {};
A.x = function (a) {
return (a * 2);
};
";
            ScriptAssert.Equal(js, "", subject.Translate(sane));
        }

        [Fact]
        public void CallFunction()
        {
            var subject = new Compiler();
            const string sane = @"
            module A
                x = (a) -> a * 2
                y = (b) -> x { b + 3 }                     
            end";

            const string js = @"A = {};
A.x = function (a) {
return (a * 2);
};
A.y = function (b) {
return A.x((b + 3));
};
";
            output.WriteLine("CallFunction");
            var result = subject.Translate(sane);
            ScriptAssert.Equal(js, "", result);
        }

        [Fact]
        public void CallFunction2()
        {
            var subject = new Compiler();
            const string sane = @"
            module A
                x = (a) -> a * 2
                y = (a b c) -> x { a { b { c } } }
                z = y {
                        (a) -> a + 1 
                        (a) -> a + 2 
                        3
                      }                             
            end";

            const string js = @"A = {};
A.x = function (a) {
return (a * 2);
};
A.y = function (a, b, c) {return A.x(a(b(c)));};
A.z = A.y(function (a) {return (a + 1);}, function (a) {return (a + 2);}, 3);
";
            output.WriteLine("CallFunction");
            var result = subject.Translate(sane);
            ScriptAssert.Equal(js, "", result);
        }


        [Fact]
        public void ExtensionValue()
        {
            var subject = new Compiler();
            const string sane = @"
            module A
                log = ```
                    function (value) { 
                        console.log(value); /*comment*/ 
                    }
                      ```
                a = 2
                b = ```\`value: ${A.a}\````
            end
";
            const string js = @"A = {};
A.log = function (value) { 
                        console.log(value); /*comment*/ 
                    };
A.a = 2;
A.b = `value: ${A.a}`;";
            var result = subject.Translate(sane);
            ScriptAssert.Equal(js, "", result);
        }
        
//        [Fact]
//        public void PipeOperator()
//        {
//            var subject = new Compiler();
//            const string sane = @"
//            module A
//                map : forall T P. List(T) -> (T -> P) -> List(P)   
//                map = ```
//                    function (list, func) { 
//                        reutn list.map(func); 
//                    }
//                      ```
//                a = [1 2 3]
//                b = a
//                |> map { func := (x) -> x + 1 }
//            end
//";
//            const string js = @"A = {};
//A.log = function (value) { 
//                        console.log(value); /*comment*/ 
//                    };
//A.a = 2;
//A.b = `value: ${A.a}`;";
//            var result = subject.Translate(sane);
//            ScriptAssert.Equal(js, "", result);
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
