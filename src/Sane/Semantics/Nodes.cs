using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Antlr4.Runtime;

namespace Sane.Semantics
{   
    public abstract class BaseNode
    {
        public IToken Token { get; set; }
    }
    
    public class ModuleNode : BaseNode
    {
        public string Id { get; set; }
        public IList<LetNode> Lets { get; set; } = new List<LetNode>();
    }

    public class LetNode : BaseNode
    {
        public string Name { get; set; }
        public ExprNode Expr { get; set; }
    }

    public abstract class ExprNode : BaseNode
    {
        
    }

    public class CallNode : ExprNode
    {
        public string Id { get; set; }
        public IList<ExprNode> Parameters { get; set; }
    }

    public class BinaryExprNode : ExprNode
    {
        public string Id { get; set; }
        public ExprNode Left { get; set; }
        public ExprNode Right { get; set; }
    }

    public class StringNode : ExprNode
    {
        public string Value { get; set; }
    }
    
    public class NumericNode : ExprNode
    {
        public decimal Value { get; set; }
    }

    public class FuncNode : ExprNode
    {
        public IList<string> Parameters { get; set; }
        public ExprNode Body { get; set; }
    }

    public class ListNode : ExprNode
    {
        public IList<ExprNode> ExprNodes { get; set; }
    }

    public class LetInNode : ExprNode
    {
        public IList<LetNode> Lets { get; set; }
        public ExprNode Body { get; set; }
    }

    public class ExternalNode : ExprNode
    {
        public string Body { get; set; }
    }
        
}