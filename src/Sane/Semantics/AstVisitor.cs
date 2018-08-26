using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Xml.Schema;
using Antlr4.Runtime;
using Sane.Semantics;

namespace Sane.Semantics
{    
    
    public abstract class AstVisitor<T>
    {
        public Errors ErrorsSink { get; }
        public abstract T Visit(ModuleNode node);
        public abstract T Visit(LetNode node);
        public abstract T Visit(ExprNode node);
        public abstract T Visit(CallNode node);
        public abstract T Visit(StringNode node);
        public abstract T Visit(NumericNode node);
        public abstract T Visit(ArrayNode node);
        public abstract T Visit(ExternalNode node);
        public abstract T Visit(BinaryExprNode node); 
        public abstract T Visit(FuncNode node);
        public abstract T Visit(ReferenceNode node);
        public abstract T Visit(LetInNode node);

        public AstVisitor(Errors errorsSink = null)
        {
            ErrorsSink = errorsSink ?? new Errors();
        }
        
        public void AddError(Error.ErrorLevel level, BaseNode node, string message)
        {
            ErrorsSink.Add(new Error
            {
                Level = level,
                Token = node.Token,
                Message = message
            });
            if (level == Error.ErrorLevel.Error)
            {
                throw new CompilationException(ErrorsSink);
            }
        }
    }
}