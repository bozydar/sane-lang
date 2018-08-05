using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Net.Security;
using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using Sane.Grammar;
using Sane.Semantics;

namespace Sane {
    public class AstBuilder : SaneBaseVisitor<BaseNode>
    {
        public Errors ErrorsSink { get; }

        public AstBuilder(Errors errorsSink = null)
        {
            ErrorsSink = errorsSink ?? new Errors();
        }
    }
}