//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.7
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from C:/Users/USER/RiderProjects/sane-lang/src/Sane\Sane.g4 by ANTLR 4.7

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
using IParseTreeListener = Antlr4.Runtime.Tree.IParseTreeListener;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete listener for a parse tree produced by
/// <see cref="SaneParser"/>.
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.7")]
[System.CLSCompliant(false)]
public interface ISaneListener : IParseTreeListener {
	/// <summary>
	/// Enter a parse tree produced by <see cref="SaneParser.module"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterModule([NotNull] SaneParser.ModuleContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="SaneParser.module"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitModule([NotNull] SaneParser.ModuleContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="SaneParser.let"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterLet([NotNull] SaneParser.LetContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="SaneParser.let"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitLet([NotNull] SaneParser.LetContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="SaneParser.parameter"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterParameter([NotNull] SaneParser.ParameterContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="SaneParser.parameter"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitParameter([NotNull] SaneParser.ParameterContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>pipeExpr</c>
	/// labeled alternative in <see cref="SaneParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterPipeExpr([NotNull] SaneParser.PipeExprContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>pipeExpr</c>
	/// labeled alternative in <see cref="SaneParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitPipeExpr([NotNull] SaneParser.PipeExprContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>numericAtomExp</c>
	/// labeled alternative in <see cref="SaneParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterNumericAtomExp([NotNull] SaneParser.NumericAtomExpContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>numericAtomExp</c>
	/// labeled alternative in <see cref="SaneParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitNumericAtomExp([NotNull] SaneParser.NumericAtomExpContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>mulDivExp</c>
	/// labeled alternative in <see cref="SaneParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterMulDivExp([NotNull] SaneParser.MulDivExpContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>mulDivExp</c>
	/// labeled alternative in <see cref="SaneParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitMulDivExp([NotNull] SaneParser.MulDivExpContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>leftPlusMinus</c>
	/// labeled alternative in <see cref="SaneParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterLeftPlusMinus([NotNull] SaneParser.LeftPlusMinusContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>leftPlusMinus</c>
	/// labeled alternative in <see cref="SaneParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitLeftPlusMinus([NotNull] SaneParser.LeftPlusMinusContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>orExpr</c>
	/// labeled alternative in <see cref="SaneParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterOrExpr([NotNull] SaneParser.OrExprContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>orExpr</c>
	/// labeled alternative in <see cref="SaneParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitOrExpr([NotNull] SaneParser.OrExprContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>arrayExp</c>
	/// labeled alternative in <see cref="SaneParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterArrayExp([NotNull] SaneParser.ArrayExpContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>arrayExp</c>
	/// labeled alternative in <see cref="SaneParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitArrayExp([NotNull] SaneParser.ArrayExpContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>externalNode</c>
	/// labeled alternative in <see cref="SaneParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterExternalNode([NotNull] SaneParser.ExternalNodeContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>externalNode</c>
	/// labeled alternative in <see cref="SaneParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitExternalNode([NotNull] SaneParser.ExternalNodeContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>idAtomExp</c>
	/// labeled alternative in <see cref="SaneParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterIdAtomExp([NotNull] SaneParser.IdAtomExpContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>idAtomExp</c>
	/// labeled alternative in <see cref="SaneParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitIdAtomExp([NotNull] SaneParser.IdAtomExpContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>addSubExp</c>
	/// labeled alternative in <see cref="SaneParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterAddSubExp([NotNull] SaneParser.AddSubExpContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>addSubExp</c>
	/// labeled alternative in <see cref="SaneParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitAddSubExp([NotNull] SaneParser.AddSubExpContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>compareExp</c>
	/// labeled alternative in <see cref="SaneParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterCompareExp([NotNull] SaneParser.CompareExpContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>compareExp</c>
	/// labeled alternative in <see cref="SaneParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitCompareExp([NotNull] SaneParser.CompareExpContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>call</c>
	/// labeled alternative in <see cref="SaneParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterCall([NotNull] SaneParser.CallContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>call</c>
	/// labeled alternative in <see cref="SaneParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitCall([NotNull] SaneParser.CallContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>notExpr</c>
	/// labeled alternative in <see cref="SaneParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterNotExpr([NotNull] SaneParser.NotExprContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>notExpr</c>
	/// labeled alternative in <see cref="SaneParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitNotExpr([NotNull] SaneParser.NotExprContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>stringAtomExp</c>
	/// labeled alternative in <see cref="SaneParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterStringAtomExp([NotNull] SaneParser.StringAtomExpContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>stringAtomExp</c>
	/// labeled alternative in <see cref="SaneParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitStringAtomExp([NotNull] SaneParser.StringAtomExpContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>composeExpr</c>
	/// labeled alternative in <see cref="SaneParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterComposeExpr([NotNull] SaneParser.ComposeExprContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>composeExpr</c>
	/// labeled alternative in <see cref="SaneParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitComposeExpr([NotNull] SaneParser.ComposeExprContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>function</c>
	/// labeled alternative in <see cref="SaneParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterFunction([NotNull] SaneParser.FunctionContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>function</c>
	/// labeled alternative in <see cref="SaneParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitFunction([NotNull] SaneParser.FunctionContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>parenthesisExp</c>
	/// labeled alternative in <see cref="SaneParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterParenthesisExp([NotNull] SaneParser.ParenthesisExpContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>parenthesisExp</c>
	/// labeled alternative in <see cref="SaneParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitParenthesisExp([NotNull] SaneParser.ParenthesisExpContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>letsInExp</c>
	/// labeled alternative in <see cref="SaneParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterLetsInExp([NotNull] SaneParser.LetsInExpContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>letsInExp</c>
	/// labeled alternative in <see cref="SaneParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitLetsInExp([NotNull] SaneParser.LetsInExpContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>andExpr</c>
	/// labeled alternative in <see cref="SaneParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterAndExpr([NotNull] SaneParser.AndExprContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>andExpr</c>
	/// labeled alternative in <see cref="SaneParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitAndExpr([NotNull] SaneParser.AndExprContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="SaneParser.declaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterDeclaration([NotNull] SaneParser.DeclarationContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="SaneParser.declaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitDeclaration([NotNull] SaneParser.DeclarationContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>commaType</c>
	/// labeled alternative in <see cref="SaneParser.type"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterCommaType([NotNull] SaneParser.CommaTypeContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>commaType</c>
	/// labeled alternative in <see cref="SaneParser.type"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitCommaType([NotNull] SaneParser.CommaTypeContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>curryType</c>
	/// labeled alternative in <see cref="SaneParser.type"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterCurryType([NotNull] SaneParser.CurryTypeContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>curryType</c>
	/// labeled alternative in <see cref="SaneParser.type"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitCurryType([NotNull] SaneParser.CurryTypeContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>parenthesisType</c>
	/// labeled alternative in <see cref="SaneParser.type"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterParenthesisType([NotNull] SaneParser.ParenthesisTypeContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>parenthesisType</c>
	/// labeled alternative in <see cref="SaneParser.type"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitParenthesisType([NotNull] SaneParser.ParenthesisTypeContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>idAtomType</c>
	/// labeled alternative in <see cref="SaneParser.type"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterIdAtomType([NotNull] SaneParser.IdAtomTypeContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>idAtomType</c>
	/// labeled alternative in <see cref="SaneParser.type"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitIdAtomType([NotNull] SaneParser.IdAtomTypeContext context);
}
} // namespace Sane.Grammar
