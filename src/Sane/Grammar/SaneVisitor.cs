//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.7
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from /home/bozydar/workspaces/sane/src/Sane/Sane.g4 by ANTLR 4.7

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

namespace Sane.Grammar {
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete generic visitor for a parse tree produced
/// by <see cref="SaneParser"/>.
/// </summary>
/// <typeparam name="Result">The return type of the visit operation.</typeparam>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.7")]
[System.CLSCompliant(false)]
public interface ISaneVisitor<Result> : IParseTreeVisitor<Result> {
	/// <summary>
	/// Visit a parse tree produced by <see cref="SaneParser.program"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitProgram([NotNull] SaneParser.ProgramContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SaneParser.module"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitModule([NotNull] SaneParser.ModuleContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SaneParser.let"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitLet([NotNull] SaneParser.LetContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SaneParser.parameter"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitParameter([NotNull] SaneParser.ParameterContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>numericAtomExp</c>
	/// labeled alternative in <see cref="SaneParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitNumericAtomExp([NotNull] SaneParser.NumericAtomExpContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>mulDivExp</c>
	/// labeled alternative in <see cref="SaneParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitMulDivExp([NotNull] SaneParser.MulDivExpContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>parenthesisExp</c>
	/// labeled alternative in <see cref="SaneParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitParenthesisExp([NotNull] SaneParser.ParenthesisExpContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>idAtomExp</c>
	/// labeled alternative in <see cref="SaneParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIdAtomExp([NotNull] SaneParser.IdAtomExpContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>addSubExp</c>
	/// labeled alternative in <see cref="SaneParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAddSubExp([NotNull] SaneParser.AddSubExpContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SaneParser.declaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitDeclaration([NotNull] SaneParser.DeclarationContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>commaType</c>
	/// labeled alternative in <see cref="SaneParser.type"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitCommaType([NotNull] SaneParser.CommaTypeContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>curryType</c>
	/// labeled alternative in <see cref="SaneParser.type"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitCurryType([NotNull] SaneParser.CurryTypeContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>parenthesisType</c>
	/// labeled alternative in <see cref="SaneParser.type"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitParenthesisType([NotNull] SaneParser.ParenthesisTypeContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>idAtomType</c>
	/// labeled alternative in <see cref="SaneParser.type"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIdAtomType([NotNull] SaneParser.IdAtomTypeContext context);
}
} // namespace Sane.Grammar
