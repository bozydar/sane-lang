using System;
using System.Collections.Generic;
using Sane.Semantics;
using Sane.Test.Utils;
using Xunit;
using Xunit.Abstractions;

namespace Sane.Test.Sane
{
    public class JsOutputVisitorTest
    {
        private readonly ITestOutputHelper output;

        public JsOutputVisitorTest(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void VisitModule()
        {
            var subject = new JsOutputVisitor();
            var module = new ModuleNode
            {
                Id = "A"                
            };
            var result = subject.Visit(module);
            const string js = @"
A = {};
";
            ScriptAssert.Equal("Warning:N/A: Module `A` is empty.", subject.ErrorsSink.GetErrorsString());
            ScriptAssert.Equal(js, result);
        }
        
        [Fact]
        public void VisitLet()
        {
            var subject = new JsOutputVisitor();
            var module = new ModuleNode
            {
                Id = "A",
                Lets = new List<LetNode>
                {
                    new LetNode
                    {
                        Name = "a",
                        Expr = new StringNode
                        {
                            Value = "dupa"
                        }
                    },
                    new LetNode
                    {
                        Name = "b",
                        Expr = new NumericNode
                        {
                            Value = 1
                        }
                    },
                }
            };
            var result = subject.Visit(module);
            const string js = @"
A = {};
A.a = ""dupa"";
A.b = 1;
";
            ScriptAssert.Equal("", subject.ErrorsSink.GetErrorsString());
            ScriptAssert.Equal(js, result);
        }
        
        [Fact]
        public void ErrorWhenBindingToTheSameName()
        {
            var subject = new JsOutputVisitor(config: new JsOutputVisitor.InstanceConfig {EmptyModuleWarning = false});
            var module = new ModuleNode
            {
                Id = "A",
                Lets = new List<LetNode>
                {
                    new LetNode
                    {
                        Name = "a",
                        Expr = new StringNode
                        {
                            Value = "dupa"
                        }
                    },
                    new LetNode
                    {
                        Name = "a",
                        Expr = new NumericNode
                        {
                            Value = 1
                        }
                    }
                }
            }; 
            var ex = Record.Exception(() => subject.Visit(module)) as CompilationException;
            
            ScriptAssert.Equal("Error:N/A: Variable `a` already exists.", ex.Errors.GetErrorsString());
        }
        
        [Fact]
        public void VisitFunc()
        {
            var subject = new JsOutputVisitor(config: new JsOutputVisitor.InstanceConfig {EmptyModuleWarning = false});
            var module = new ModuleNode
            {
                Id = "A",
                Lets = new List<LetNode>
                {
                    new LetNode
                    {
                        Name = "f",
                        Expr = new FuncNode
                        {
                            Parameters = new List<string>
                            {
                                "arg0", "arg1"                                
                            }, 
                            Body   = new BinaryExprNode
                            {
                                Id = "+",
                                Left = new StringNode
                                {
                                    Value = "dupa"
                                },
                                Right = new StringNode
                                {
                                    Value = "zimna"
                                }
                            } 
                                
                        }                        
                    }
                }
            }; 

            const string js = @"
A = {};
A.f = function (arg0, arg1) {
return ""dupa"" + ""zimna"";
};
";
            var result = subject.Visit(module);
            ScriptAssert.Equal("", subject.ErrorsSink.GetErrorsString());
            ScriptAssert.Equal(js, result);
        }
        
        [Fact]
        public void VisitList()
        {
            var subject = new JsOutputVisitor(config: new JsOutputVisitor.InstanceConfig {EmptyModuleWarning = false});
            var module = new ModuleNode
            {
                Id = "A",
                Lets = new List<LetNode>
                {
                    new LetNode
                    {
                        Name = "a",
                        Expr = new StringNode
                        {
                            Value = "dupa"
                        }
                    },
                    new LetNode
                    {
                        Name = "a",
                        Expr = new NumericNode
                        {
                            Value = 1
                        }
                    }
                }
            }; 
            var ex = Record.Exception(() => subject.Visit(module)) as CompilationException;
            
            ScriptAssert.Equal("Error:N/A: Variable `a` already exists.", ex.Errors.GetErrorsString());
        }
    }
}