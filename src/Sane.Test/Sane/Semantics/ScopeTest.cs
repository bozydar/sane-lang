using System;
using System.Reflection;
using Antlr4.Runtime;
using Xunit;
using Sane;
using Sane.Semantics;
using Xunit.Abstractions;

namespace Sane.Test.Sane.Semantics
{
//    public class ScopeTest
//    {
//        private readonly ITestOutputHelper output;
//
//        public ScopeTest(ITestOutputHelper output)
//        {
//            this.output = output;
//        }
//
//        class MockToken : IToken
//        {
//            public string Text { get; }
//            public int Type { get; }
//            public int Line { get; }
//            public int Column { get; }
//            public int Channel { get; }
//            public int TokenIndex { get; }
//            public int StartIndex { get; }
//            public int StopIndex { get; }
//            public ITokenSource TokenSource { get; }
//            public ICharStream InputStream { get; }
//        }
//        
//        [Fact]        
//        public void CanAddAnewSymbol()
//        {
//            var subject = new Sane.Semantics.Scope();
//
//            subject.AddSymbol(new Binding("variable", new MockToken()));
//            Assert.Equal(subject.FindSymbol("variable").Name, "variable"); 
//            Assert.Null(subject.FindSymbol("unknown"));
//        }
//        
//        [Fact]        
//        public void CanFindInParentScope()
//        {
//            var parent = new Scope();
//            parent.AddSymbol(new Binding("parentVariable", new MockToken()));
//            var child = parent.CreateChildScope();
//            child.AddSymbol(new Binding("childVariable", new MockToken()));
//            
//            Assert.Equal(child.FindSymbol("childVariable").Name, "childVariable"); 
//            Assert.Equal(child.FindSymbol("parentVariable").Name, "parentVariable"); 
//            Assert.Null(child.FindSymbol("unknown"));
//        }
//    }
}