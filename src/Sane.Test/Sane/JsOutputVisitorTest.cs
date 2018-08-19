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
                        Id = "a",
                        Expr = new StringNode
                        {
                            Value = "dupa"
                        }
                    },
                    new LetNode
                    {
                        Id = "b",
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
                        Id = "a",
                        Expr = new StringNode
                        {
                            Value = "dupa"
                        }
                    },
                    new LetNode
                    {
                        Id = "a",
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
                        Id = "out",
                        Expr = new NumericNode
                        {
                            Value = 10
                        }
                    },
                    new LetNode
                    {
                        Id = "f",
                        Expr = new FuncNode
                        {
                            Parameters = new List<ParamNode>
                            {
                                new ParamNode
                                {
                                    Id = "arg0"
                                },
                                new ParamNode
                                {
                                    Id = "arg1"
                                }
                            },
                            Body = new BinaryExprNode
                            {
                                Id = "+",
                                Left = new StringNode
                                {
                                    Value = "dupa"
                                },
                                Right = new BinaryExprNode
                                {
                                    Id = "+",
                                    Left = new ReferenceNode
                                    {
                                        Id = "arg0"
                                    },
                                    Right = new ReferenceNode
                                    {
                                        Id = "out"
                                    }
                                }
                            }
                        }
                    }
                }
            };

            const string js = @"
A = {};
A.out = 10;
A.f = function (arg0, arg1) {
return (""dupa"" + (arg0 + A.out));
};
";
            var result = subject.Visit(module);
            ScriptAssert.Equal("", subject.ErrorsSink.GetErrorsString());
            ScriptAssert.Equal(js, result);
        }

        [Fact]
        public void VisitLetInNode()
        {
            var subject = new JsOutputVisitor(config: new JsOutputVisitor.InstanceConfig {EmptyModuleWarning = false});
            var module = new ModuleNode
            {
                Id = "A",
                Lets = new List<LetNode>
                {
                    new LetNode
                    {
                        Id = "evalNow",
                        Expr = new LetInNode
                        {
                            Lets = new List<LetNode>
                            {
                                new LetNode
                                {
                                    Id = "a",
                                    Expr = new NumericNode
                                    {
                                        Value = 1
                                    }
                                },
                                new LetNode
                                {
                                    Id = "b",
                                    Expr = new NumericNode
                                    {
                                        Value = 2
                                    }
                                }
                            },
                            Body = new BinaryExprNode
                            {
                                Id = "+",
                                Left = new ReferenceNode
                                {
                                    Id = "a"
                                },
                                Right = new ReferenceNode
                                {
                                    Id = "b"
                                }
                            }
                        }
                    }
                }
            };

            const string js = @"
A = {};
A.evalNow = function () {
var a = 1;
var b = 2;
return (a + b);
}();
";
            var result = subject.Visit(module);
            ScriptAssert.Equal("", subject.ErrorsSink.GetErrorsString());
            ScriptAssert.Equal(js, result);
        }

        [Fact]
        public void VisitCall()
        {
            var subject = new JsOutputVisitor(config: new JsOutputVisitor.InstanceConfig {EmptyModuleWarning = false});
            var module = new ModuleNode
            {
                Id = "A",
                Lets = new List<LetNode>
                {
                    new LetNode
                    {
                        Id = "f",
                        Expr = new FuncNode
                        {
                            Parameters = new List<ParamNode>
                            {
                                new ParamNode
                                {
                                    Id = "arg0"
                                },
                                new ParamNode
                                {
                                    Id = "arg1"
                                }
                            },
                            Body = new BinaryExprNode
                            {
                                Id = "+",
                                Left = new ReferenceNode
                                {
                                    Id = "arg0"
                                },
                                Right = new ReferenceNode
                                {
                                    Id = "arg1"
                                }
                            }
                        }
                    },
                    new LetNode
                    {
                        Id = "main",
                        Expr = new FuncNode
                        {           
                            Parameters = new List<ParamNode>(),
                            Body = new LetInNode
                            {
                                Lets = new List<LetNode>
                                {
                                    new LetNode
                                    {
                                        Id = "x",
                                        Expr = new NumericNode
                                        {
                                            Value = 1
                                        }
                                    }
                                },
                                Body = new CallNode
                                {
                                    Expr = new ReferenceNode
                                    {
                                        Id = "f"
                                    },
                                    Parameters = new List<ExprNode>
                                    {
                                        new ReferenceNode
                                        {
                                            Id = "x"
                                        },
                                        new NumericNode
                                        {
                                            Value = 2
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            };

            const string js = @"
A = {};
A.f = function (arg0, arg1) {
return (arg0 + arg1);
};
A.main = function () {
return function () {
var x = 1;
return A.f(x, 2);
}();
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
                        Id = "a",
                        Expr = new StringNode
                        {
                            Value = "dupa"
                        }
                    },
                    new LetNode
                    {
                        Id = "a",
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