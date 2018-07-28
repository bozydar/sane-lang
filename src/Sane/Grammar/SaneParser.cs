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
using System;
using System.IO;
using System.Text;
using System.Diagnostics;
using System.Collections.Generic;
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using DFA = Antlr4.Runtime.Dfa.DFA;

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.7")]
[System.CLSCompliant(false)]
public partial class SaneParser : Parser {
	protected static DFA[] decisionToDFA;
	protected static PredictionContextCache sharedContextCache = new PredictionContextCache();
	public const int
		T__0=1, T__1=2, T__2=3, T__3=4, T__4=5, T__5=6, T__6=7, T__7=8, T__8=9, 
		ID=10, ASTERISK=11, SLASH=12, PLUS=13, MINUS=14, NUMBER=15, WHITESPACE=16, 
		SingleLineComment=17;
	public const int
		RULE_module = 0, RULE_let = 1, RULE_parameter = 2, RULE_expression = 3, 
		RULE_declaration = 4, RULE_type = 5;
	public static readonly string[] ruleNames = {
		"module", "let", "parameter", "expression", "declaration", "type"
	};

	private static readonly string[] _LiteralNames = {
		null, "'module'", "'end'", "'let'", "'='", "'('", "')'", "'->'", "':'", 
		"','", null, "'*'", "'/'", "'+'", "'-'"
	};
	private static readonly string[] _SymbolicNames = {
		null, null, null, null, null, null, null, null, null, null, "ID", "ASTERISK", 
		"SLASH", "PLUS", "MINUS", "NUMBER", "WHITESPACE", "SingleLineComment"
	};
	public static readonly IVocabulary DefaultVocabulary = new Vocabulary(_LiteralNames, _SymbolicNames);

	[NotNull]
	public override IVocabulary Vocabulary
	{
		get
		{
			return DefaultVocabulary;
		}
	}

	public override string GrammarFileName { get { return "Sane.g4"; } }

	public override string[] RuleNames { get { return ruleNames; } }

	public override string SerializedAtn { get { return new string(_serializedATN); } }

	static SaneParser() {
		decisionToDFA = new DFA[_ATN.NumberOfDecisions];
		for (int i = 0; i < _ATN.NumberOfDecisions; i++) {
			decisionToDFA[i] = new DFA(_ATN.GetDecisionState(i), i);
		}
	}

		public SaneParser(ITokenStream input) : this(input, Console.Out, Console.Error) { }

		public SaneParser(ITokenStream input, TextWriter output, TextWriter errorOutput)
		: base(input, output, errorOutput)
	{
		Interpreter = new ParserATNSimulator(this, _ATN, decisionToDFA, sharedContextCache);
	}
	public partial class ModuleContext : ParserRuleContext {
		public IToken moduleName;
		public ITerminalNode ID() { return GetToken(SaneParser.ID, 0); }
		public DeclarationContext[] declaration() {
			return GetRuleContexts<DeclarationContext>();
		}
		public DeclarationContext declaration(int i) {
			return GetRuleContext<DeclarationContext>(i);
		}
		public LetContext[] let() {
			return GetRuleContexts<LetContext>();
		}
		public LetContext let(int i) {
			return GetRuleContext<LetContext>(i);
		}
		public ModuleContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_module; } }
		public override void EnterRule(IParseTreeListener listener) {
			ISaneListener typedListener = listener as ISaneListener;
			if (typedListener != null) typedListener.EnterModule(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			ISaneListener typedListener = listener as ISaneListener;
			if (typedListener != null) typedListener.ExitModule(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ISaneVisitor<TResult> typedVisitor = visitor as ISaneVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitModule(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public ModuleContext module() {
		ModuleContext _localctx = new ModuleContext(Context, State);
		EnterRule(_localctx, 0, RULE_module);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 12; Match(T__0);
			State = 13; _localctx.moduleName = Match(ID);
			State = 18;
			ErrorHandler.Sync(this);
			_la = TokenStream.LA(1);
			while (_la==T__2 || _la==ID) {
				{
				State = 16;
				ErrorHandler.Sync(this);
				switch (TokenStream.LA(1)) {
				case ID:
					{
					State = 14; declaration();
					}
					break;
				case T__2:
					{
					State = 15; let();
					}
					break;
				default:
					throw new NoViableAltException(this);
				}
				}
				State = 20;
				ErrorHandler.Sync(this);
				_la = TokenStream.LA(1);
			}
			State = 21; Match(T__1);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class LetContext : ParserRuleContext {
		public IToken bindingName;
		public ExpressionContext expression() {
			return GetRuleContext<ExpressionContext>(0);
		}
		public ITerminalNode ID() { return GetToken(SaneParser.ID, 0); }
		public LetContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_let; } }
		public override void EnterRule(IParseTreeListener listener) {
			ISaneListener typedListener = listener as ISaneListener;
			if (typedListener != null) typedListener.EnterLet(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			ISaneListener typedListener = listener as ISaneListener;
			if (typedListener != null) typedListener.ExitLet(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ISaneVisitor<TResult> typedVisitor = visitor as ISaneVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitLet(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public LetContext let() {
		LetContext _localctx = new LetContext(Context, State);
		EnterRule(_localctx, 2, RULE_let);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 23; Match(T__2);
			State = 24; _localctx.bindingName = Match(ID);
			State = 25; Match(T__3);
			State = 26; expression(0);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class ParameterContext : ParserRuleContext {
		public ITerminalNode ID() { return GetToken(SaneParser.ID, 0); }
		public ParameterContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_parameter; } }
		public override void EnterRule(IParseTreeListener listener) {
			ISaneListener typedListener = listener as ISaneListener;
			if (typedListener != null) typedListener.EnterParameter(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			ISaneListener typedListener = listener as ISaneListener;
			if (typedListener != null) typedListener.ExitParameter(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ISaneVisitor<TResult> typedVisitor = visitor as ISaneVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitParameter(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public ParameterContext parameter() {
		ParameterContext _localctx = new ParameterContext(Context, State);
		EnterRule(_localctx, 4, RULE_parameter);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 28; Match(ID);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class ExpressionContext : ParserRuleContext {
		public ExpressionContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_expression; } }
	 
		public ExpressionContext() { }
		public virtual void CopyFrom(ExpressionContext context) {
			base.CopyFrom(context);
		}
	}
	public partial class CallContext : ExpressionContext {
		public IToken funcName;
		public ExpressionContext expressions;
		public ITerminalNode ID() { return GetToken(SaneParser.ID, 0); }
		public ExpressionContext[] expression() {
			return GetRuleContexts<ExpressionContext>();
		}
		public ExpressionContext expression(int i) {
			return GetRuleContext<ExpressionContext>(i);
		}
		public CallContext(ExpressionContext context) { CopyFrom(context); }
		public override void EnterRule(IParseTreeListener listener) {
			ISaneListener typedListener = listener as ISaneListener;
			if (typedListener != null) typedListener.EnterCall(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			ISaneListener typedListener = listener as ISaneListener;
			if (typedListener != null) typedListener.ExitCall(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ISaneVisitor<TResult> typedVisitor = visitor as ISaneVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitCall(this);
			else return visitor.VisitChildren(this);
		}
	}
	public partial class NumericAtomExpContext : ExpressionContext {
		public IToken value;
		public ITerminalNode NUMBER() { return GetToken(SaneParser.NUMBER, 0); }
		public NumericAtomExpContext(ExpressionContext context) { CopyFrom(context); }
		public override void EnterRule(IParseTreeListener listener) {
			ISaneListener typedListener = listener as ISaneListener;
			if (typedListener != null) typedListener.EnterNumericAtomExp(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			ISaneListener typedListener = listener as ISaneListener;
			if (typedListener != null) typedListener.ExitNumericAtomExp(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ISaneVisitor<TResult> typedVisitor = visitor as ISaneVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitNumericAtomExp(this);
			else return visitor.VisitChildren(this);
		}
	}
	public partial class MulDivExpContext : ExpressionContext {
		public ExpressionContext left;
		public IToken operation;
		public ExpressionContext right;
		public ExpressionContext[] expression() {
			return GetRuleContexts<ExpressionContext>();
		}
		public ExpressionContext expression(int i) {
			return GetRuleContext<ExpressionContext>(i);
		}
		public ITerminalNode ASTERISK() { return GetToken(SaneParser.ASTERISK, 0); }
		public ITerminalNode SLASH() { return GetToken(SaneParser.SLASH, 0); }
		public MulDivExpContext(ExpressionContext context) { CopyFrom(context); }
		public override void EnterRule(IParseTreeListener listener) {
			ISaneListener typedListener = listener as ISaneListener;
			if (typedListener != null) typedListener.EnterMulDivExp(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			ISaneListener typedListener = listener as ISaneListener;
			if (typedListener != null) typedListener.ExitMulDivExp(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ISaneVisitor<TResult> typedVisitor = visitor as ISaneVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitMulDivExp(this);
			else return visitor.VisitChildren(this);
		}
	}
	public partial class FunctionContext : ExpressionContext {
		public ParameterContext parameters;
		public ExpressionContext body;
		public ExpressionContext expression() {
			return GetRuleContext<ExpressionContext>(0);
		}
		public ParameterContext[] parameter() {
			return GetRuleContexts<ParameterContext>();
		}
		public ParameterContext parameter(int i) {
			return GetRuleContext<ParameterContext>(i);
		}
		public FunctionContext(ExpressionContext context) { CopyFrom(context); }
		public override void EnterRule(IParseTreeListener listener) {
			ISaneListener typedListener = listener as ISaneListener;
			if (typedListener != null) typedListener.EnterFunction(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			ISaneListener typedListener = listener as ISaneListener;
			if (typedListener != null) typedListener.ExitFunction(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ISaneVisitor<TResult> typedVisitor = visitor as ISaneVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitFunction(this);
			else return visitor.VisitChildren(this);
		}
	}
	public partial class ParenthesisExpContext : ExpressionContext {
		public ExpressionContext expression() {
			return GetRuleContext<ExpressionContext>(0);
		}
		public ParenthesisExpContext(ExpressionContext context) { CopyFrom(context); }
		public override void EnterRule(IParseTreeListener listener) {
			ISaneListener typedListener = listener as ISaneListener;
			if (typedListener != null) typedListener.EnterParenthesisExp(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			ISaneListener typedListener = listener as ISaneListener;
			if (typedListener != null) typedListener.ExitParenthesisExp(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ISaneVisitor<TResult> typedVisitor = visitor as ISaneVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitParenthesisExp(this);
			else return visitor.VisitChildren(this);
		}
	}
	public partial class IdAtomExpContext : ExpressionContext {
		public ITerminalNode ID() { return GetToken(SaneParser.ID, 0); }
		public IdAtomExpContext(ExpressionContext context) { CopyFrom(context); }
		public override void EnterRule(IParseTreeListener listener) {
			ISaneListener typedListener = listener as ISaneListener;
			if (typedListener != null) typedListener.EnterIdAtomExp(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			ISaneListener typedListener = listener as ISaneListener;
			if (typedListener != null) typedListener.ExitIdAtomExp(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ISaneVisitor<TResult> typedVisitor = visitor as ISaneVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitIdAtomExp(this);
			else return visitor.VisitChildren(this);
		}
	}
	public partial class AddSubExpContext : ExpressionContext {
		public ExpressionContext left;
		public IToken operation;
		public ExpressionContext right;
		public ExpressionContext[] expression() {
			return GetRuleContexts<ExpressionContext>();
		}
		public ExpressionContext expression(int i) {
			return GetRuleContext<ExpressionContext>(i);
		}
		public ITerminalNode PLUS() { return GetToken(SaneParser.PLUS, 0); }
		public ITerminalNode MINUS() { return GetToken(SaneParser.MINUS, 0); }
		public AddSubExpContext(ExpressionContext context) { CopyFrom(context); }
		public override void EnterRule(IParseTreeListener listener) {
			ISaneListener typedListener = listener as ISaneListener;
			if (typedListener != null) typedListener.EnterAddSubExp(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			ISaneListener typedListener = listener as ISaneListener;
			if (typedListener != null) typedListener.ExitAddSubExp(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ISaneVisitor<TResult> typedVisitor = visitor as ISaneVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitAddSubExp(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public ExpressionContext expression() {
		return expression(0);
	}

	private ExpressionContext expression(int _p) {
		ParserRuleContext _parentctx = Context;
		int _parentState = State;
		ExpressionContext _localctx = new ExpressionContext(Context, _parentState);
		ExpressionContext _prevctx = _localctx;
		int _startState = 6;
		EnterRecursionRule(_localctx, 6, RULE_expression, _p);
		int _la;
		try {
			int _alt;
			EnterOuterAlt(_localctx, 1);
			{
			State = 56;
			ErrorHandler.Sync(this);
			switch ( Interpreter.AdaptivePredict(TokenStream,4,Context) ) {
			case 1:
				{
				_localctx = new ParenthesisExpContext(_localctx);
				Context = _localctx;
				_prevctx = _localctx;

				State = 31; Match(T__4);
				State = 32; expression(0);
				State = 33; Match(T__5);
				}
				break;
			case 2:
				{
				_localctx = new CallContext(_localctx);
				Context = _localctx;
				_prevctx = _localctx;
				State = 35; ((CallContext)_localctx).funcName = Match(ID);
				State = 36; Match(T__4);
				State = 40;
				ErrorHandler.Sync(this);
				_la = TokenStream.LA(1);
				while ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << T__4) | (1L << ID) | (1L << NUMBER))) != 0)) {
					{
					{
					State = 37; ((CallContext)_localctx).expressions = expression(0);
					}
					}
					State = 42;
					ErrorHandler.Sync(this);
					_la = TokenStream.LA(1);
				}
				State = 43; Match(T__5);
				}
				break;
			case 3:
				{
				_localctx = new FunctionContext(_localctx);
				Context = _localctx;
				_prevctx = _localctx;
				State = 44; Match(T__4);
				State = 48;
				ErrorHandler.Sync(this);
				_la = TokenStream.LA(1);
				while (_la==ID) {
					{
					{
					State = 45; ((FunctionContext)_localctx).parameters = parameter();
					}
					}
					State = 50;
					ErrorHandler.Sync(this);
					_la = TokenStream.LA(1);
				}
				State = 51; Match(T__5);
				State = 52; Match(T__6);
				State = 53; ((FunctionContext)_localctx).body = expression(3);
				}
				break;
			case 4:
				{
				_localctx = new NumericAtomExpContext(_localctx);
				Context = _localctx;
				_prevctx = _localctx;
				State = 54; ((NumericAtomExpContext)_localctx).value = Match(NUMBER);
				}
				break;
			case 5:
				{
				_localctx = new IdAtomExpContext(_localctx);
				Context = _localctx;
				_prevctx = _localctx;
				State = 55; Match(ID);
				}
				break;
			}
			Context.Stop = TokenStream.LT(-1);
			State = 66;
			ErrorHandler.Sync(this);
			_alt = Interpreter.AdaptivePredict(TokenStream,6,Context);
			while ( _alt!=2 && _alt!=global::Antlr4.Runtime.Atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1 ) {
					if ( ParseListeners!=null )
						TriggerExitRuleEvent();
					_prevctx = _localctx;
					{
					State = 64;
					ErrorHandler.Sync(this);
					switch ( Interpreter.AdaptivePredict(TokenStream,5,Context) ) {
					case 1:
						{
						_localctx = new MulDivExpContext(new ExpressionContext(_parentctx, _parentState));
						((MulDivExpContext)_localctx).left = _prevctx;
						PushNewRecursionContext(_localctx, _startState, RULE_expression);
						State = 58;
						if (!(Precpred(Context, 6))) throw new FailedPredicateException(this, "Precpred(Context, 6)");
						State = 59;
						((MulDivExpContext)_localctx).operation = TokenStream.LT(1);
						_la = TokenStream.LA(1);
						if ( !(_la==ASTERISK || _la==SLASH) ) {
							((MulDivExpContext)_localctx).operation = ErrorHandler.RecoverInline(this);
						}
						else {
							ErrorHandler.ReportMatch(this);
						    Consume();
						}
						State = 60; ((MulDivExpContext)_localctx).right = expression(7);
						}
						break;
					case 2:
						{
						_localctx = new AddSubExpContext(new ExpressionContext(_parentctx, _parentState));
						((AddSubExpContext)_localctx).left = _prevctx;
						PushNewRecursionContext(_localctx, _startState, RULE_expression);
						State = 61;
						if (!(Precpred(Context, 5))) throw new FailedPredicateException(this, "Precpred(Context, 5)");
						State = 62;
						((AddSubExpContext)_localctx).operation = TokenStream.LT(1);
						_la = TokenStream.LA(1);
						if ( !(_la==PLUS || _la==MINUS) ) {
							((AddSubExpContext)_localctx).operation = ErrorHandler.RecoverInline(this);
						}
						else {
							ErrorHandler.ReportMatch(this);
						    Consume();
						}
						State = 63; ((AddSubExpContext)_localctx).right = expression(6);
						}
						break;
					}
					} 
				}
				State = 68;
				ErrorHandler.Sync(this);
				_alt = Interpreter.AdaptivePredict(TokenStream,6,Context);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			UnrollRecursionContexts(_parentctx);
		}
		return _localctx;
	}

	public partial class DeclarationContext : ParserRuleContext {
		public ITerminalNode ID() { return GetToken(SaneParser.ID, 0); }
		public TypeContext type() {
			return GetRuleContext<TypeContext>(0);
		}
		public DeclarationContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_declaration; } }
		public override void EnterRule(IParseTreeListener listener) {
			ISaneListener typedListener = listener as ISaneListener;
			if (typedListener != null) typedListener.EnterDeclaration(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			ISaneListener typedListener = listener as ISaneListener;
			if (typedListener != null) typedListener.ExitDeclaration(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ISaneVisitor<TResult> typedVisitor = visitor as ISaneVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitDeclaration(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public DeclarationContext declaration() {
		DeclarationContext _localctx = new DeclarationContext(Context, State);
		EnterRule(_localctx, 8, RULE_declaration);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 69; Match(ID);
			State = 70; Match(T__7);
			State = 71; type(0);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class TypeContext : ParserRuleContext {
		public TypeContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_type; } }
	 
		public TypeContext() { }
		public virtual void CopyFrom(TypeContext context) {
			base.CopyFrom(context);
		}
	}
	public partial class CommaTypeContext : TypeContext {
		public TypeContext[] type() {
			return GetRuleContexts<TypeContext>();
		}
		public TypeContext type(int i) {
			return GetRuleContext<TypeContext>(i);
		}
		public CommaTypeContext(TypeContext context) { CopyFrom(context); }
		public override void EnterRule(IParseTreeListener listener) {
			ISaneListener typedListener = listener as ISaneListener;
			if (typedListener != null) typedListener.EnterCommaType(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			ISaneListener typedListener = listener as ISaneListener;
			if (typedListener != null) typedListener.ExitCommaType(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ISaneVisitor<TResult> typedVisitor = visitor as ISaneVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitCommaType(this);
			else return visitor.VisitChildren(this);
		}
	}
	public partial class CurryTypeContext : TypeContext {
		public TypeContext[] type() {
			return GetRuleContexts<TypeContext>();
		}
		public TypeContext type(int i) {
			return GetRuleContext<TypeContext>(i);
		}
		public CurryTypeContext(TypeContext context) { CopyFrom(context); }
		public override void EnterRule(IParseTreeListener listener) {
			ISaneListener typedListener = listener as ISaneListener;
			if (typedListener != null) typedListener.EnterCurryType(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			ISaneListener typedListener = listener as ISaneListener;
			if (typedListener != null) typedListener.ExitCurryType(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ISaneVisitor<TResult> typedVisitor = visitor as ISaneVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitCurryType(this);
			else return visitor.VisitChildren(this);
		}
	}
	public partial class ParenthesisTypeContext : TypeContext {
		public TypeContext[] type() {
			return GetRuleContexts<TypeContext>();
		}
		public TypeContext type(int i) {
			return GetRuleContext<TypeContext>(i);
		}
		public ParenthesisTypeContext(TypeContext context) { CopyFrom(context); }
		public override void EnterRule(IParseTreeListener listener) {
			ISaneListener typedListener = listener as ISaneListener;
			if (typedListener != null) typedListener.EnterParenthesisType(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			ISaneListener typedListener = listener as ISaneListener;
			if (typedListener != null) typedListener.ExitParenthesisType(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ISaneVisitor<TResult> typedVisitor = visitor as ISaneVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitParenthesisType(this);
			else return visitor.VisitChildren(this);
		}
	}
	public partial class IdAtomTypeContext : TypeContext {
		public ITerminalNode ID() { return GetToken(SaneParser.ID, 0); }
		public IdAtomTypeContext(TypeContext context) { CopyFrom(context); }
		public override void EnterRule(IParseTreeListener listener) {
			ISaneListener typedListener = listener as ISaneListener;
			if (typedListener != null) typedListener.EnterIdAtomType(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			ISaneListener typedListener = listener as ISaneListener;
			if (typedListener != null) typedListener.ExitIdAtomType(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ISaneVisitor<TResult> typedVisitor = visitor as ISaneVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitIdAtomType(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public TypeContext type() {
		return type(0);
	}

	private TypeContext type(int _p) {
		ParserRuleContext _parentctx = Context;
		int _parentState = State;
		TypeContext _localctx = new TypeContext(Context, _parentState);
		TypeContext _prevctx = _localctx;
		int _startState = 10;
		EnterRecursionRule(_localctx, 10, RULE_type, _p);
		int _la;
		try {
			int _alt;
			EnterOuterAlt(_localctx, 1);
			{
			State = 83;
			ErrorHandler.Sync(this);
			switch (TokenStream.LA(1)) {
			case T__4:
				{
				_localctx = new ParenthesisTypeContext(_localctx);
				Context = _localctx;
				_prevctx = _localctx;

				State = 74; Match(T__4);
				State = 76;
				ErrorHandler.Sync(this);
				_la = TokenStream.LA(1);
				do {
					{
					{
					State = 75; type(0);
					}
					}
					State = 78;
					ErrorHandler.Sync(this);
					_la = TokenStream.LA(1);
				} while ( _la==T__4 || _la==ID );
				State = 80; Match(T__5);
				}
				break;
			case ID:
				{
				_localctx = new IdAtomTypeContext(_localctx);
				Context = _localctx;
				_prevctx = _localctx;
				State = 82; Match(ID);
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
			Context.Stop = TokenStream.LT(-1);
			State = 93;
			ErrorHandler.Sync(this);
			_alt = Interpreter.AdaptivePredict(TokenStream,10,Context);
			while ( _alt!=2 && _alt!=global::Antlr4.Runtime.Atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1 ) {
					if ( ParseListeners!=null )
						TriggerExitRuleEvent();
					_prevctx = _localctx;
					{
					State = 91;
					ErrorHandler.Sync(this);
					switch ( Interpreter.AdaptivePredict(TokenStream,9,Context) ) {
					case 1:
						{
						_localctx = new CommaTypeContext(new TypeContext(_parentctx, _parentState));
						PushNewRecursionContext(_localctx, _startState, RULE_type);
						State = 85;
						if (!(Precpred(Context, 3))) throw new FailedPredicateException(this, "Precpred(Context, 3)");
						State = 86; Match(T__8);
						State = 87; type(4);
						}
						break;
					case 2:
						{
						_localctx = new CurryTypeContext(new TypeContext(_parentctx, _parentState));
						PushNewRecursionContext(_localctx, _startState, RULE_type);
						State = 88;
						if (!(Precpred(Context, 2))) throw new FailedPredicateException(this, "Precpred(Context, 2)");
						State = 89; Match(T__6);
						State = 90; type(3);
						}
						break;
					}
					} 
				}
				State = 95;
				ErrorHandler.Sync(this);
				_alt = Interpreter.AdaptivePredict(TokenStream,10,Context);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			UnrollRecursionContexts(_parentctx);
		}
		return _localctx;
	}

	public override bool Sempred(RuleContext _localctx, int ruleIndex, int predIndex) {
		switch (ruleIndex) {
		case 3: return expression_sempred((ExpressionContext)_localctx, predIndex);
		case 5: return type_sempred((TypeContext)_localctx, predIndex);
		}
		return true;
	}
	private bool expression_sempred(ExpressionContext _localctx, int predIndex) {
		switch (predIndex) {
		case 0: return Precpred(Context, 6);
		case 1: return Precpred(Context, 5);
		}
		return true;
	}
	private bool type_sempred(TypeContext _localctx, int predIndex) {
		switch (predIndex) {
		case 2: return Precpred(Context, 3);
		case 3: return Precpred(Context, 2);
		}
		return true;
	}

	private static char[] _serializedATN = {
		'\x3', '\x608B', '\xA72A', '\x8133', '\xB9ED', '\x417C', '\x3BE7', '\x7786', 
		'\x5964', '\x3', '\x13', '\x63', '\x4', '\x2', '\t', '\x2', '\x4', '\x3', 
		'\t', '\x3', '\x4', '\x4', '\t', '\x4', '\x4', '\x5', '\t', '\x5', '\x4', 
		'\x6', '\t', '\x6', '\x4', '\a', '\t', '\a', '\x3', '\x2', '\x3', '\x2', 
		'\x3', '\x2', '\x3', '\x2', '\a', '\x2', '\x13', '\n', '\x2', '\f', '\x2', 
		'\xE', '\x2', '\x16', '\v', '\x2', '\x3', '\x2', '\x3', '\x2', '\x3', 
		'\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', 
		'\x4', '\x3', '\x4', '\x3', '\x5', '\x3', '\x5', '\x3', '\x5', '\x3', 
		'\x5', '\x3', '\x5', '\x3', '\x5', '\x3', '\x5', '\x3', '\x5', '\a', '\x5', 
		')', '\n', '\x5', '\f', '\x5', '\xE', '\x5', ',', '\v', '\x5', '\x3', 
		'\x5', '\x3', '\x5', '\x3', '\x5', '\a', '\x5', '\x31', '\n', '\x5', '\f', 
		'\x5', '\xE', '\x5', '\x34', '\v', '\x5', '\x3', '\x5', '\x3', '\x5', 
		'\x3', '\x5', '\x3', '\x5', '\x3', '\x5', '\x5', '\x5', ';', '\n', '\x5', 
		'\x3', '\x5', '\x3', '\x5', '\x3', '\x5', '\x3', '\x5', '\x3', '\x5', 
		'\x3', '\x5', '\a', '\x5', '\x43', '\n', '\x5', '\f', '\x5', '\xE', '\x5', 
		'\x46', '\v', '\x5', '\x3', '\x6', '\x3', '\x6', '\x3', '\x6', '\x3', 
		'\x6', '\x3', '\a', '\x3', '\a', '\x3', '\a', '\x6', '\a', 'O', '\n', 
		'\a', '\r', '\a', '\xE', '\a', 'P', '\x3', '\a', '\x3', '\a', '\x3', '\a', 
		'\x5', '\a', 'V', '\n', '\a', '\x3', '\a', '\x3', '\a', '\x3', '\a', '\x3', 
		'\a', '\x3', '\a', '\x3', '\a', '\a', '\a', '^', '\n', '\a', '\f', '\a', 
		'\xE', '\a', '\x61', '\v', '\a', '\x3', '\a', '\x2', '\x4', '\b', '\f', 
		'\b', '\x2', '\x4', '\x6', '\b', '\n', '\f', '\x2', '\x4', '\x3', '\x2', 
		'\r', '\xE', '\x3', '\x2', '\xF', '\x10', '\x2', 'j', '\x2', '\xE', '\x3', 
		'\x2', '\x2', '\x2', '\x4', '\x19', '\x3', '\x2', '\x2', '\x2', '\x6', 
		'\x1E', '\x3', '\x2', '\x2', '\x2', '\b', ':', '\x3', '\x2', '\x2', '\x2', 
		'\n', 'G', '\x3', '\x2', '\x2', '\x2', '\f', 'U', '\x3', '\x2', '\x2', 
		'\x2', '\xE', '\xF', '\a', '\x3', '\x2', '\x2', '\xF', '\x14', '\a', '\f', 
		'\x2', '\x2', '\x10', '\x13', '\x5', '\n', '\x6', '\x2', '\x11', '\x13', 
		'\x5', '\x4', '\x3', '\x2', '\x12', '\x10', '\x3', '\x2', '\x2', '\x2', 
		'\x12', '\x11', '\x3', '\x2', '\x2', '\x2', '\x13', '\x16', '\x3', '\x2', 
		'\x2', '\x2', '\x14', '\x12', '\x3', '\x2', '\x2', '\x2', '\x14', '\x15', 
		'\x3', '\x2', '\x2', '\x2', '\x15', '\x17', '\x3', '\x2', '\x2', '\x2', 
		'\x16', '\x14', '\x3', '\x2', '\x2', '\x2', '\x17', '\x18', '\a', '\x4', 
		'\x2', '\x2', '\x18', '\x3', '\x3', '\x2', '\x2', '\x2', '\x19', '\x1A', 
		'\a', '\x5', '\x2', '\x2', '\x1A', '\x1B', '\a', '\f', '\x2', '\x2', '\x1B', 
		'\x1C', '\a', '\x6', '\x2', '\x2', '\x1C', '\x1D', '\x5', '\b', '\x5', 
		'\x2', '\x1D', '\x5', '\x3', '\x2', '\x2', '\x2', '\x1E', '\x1F', '\a', 
		'\f', '\x2', '\x2', '\x1F', '\a', '\x3', '\x2', '\x2', '\x2', ' ', '!', 
		'\b', '\x5', '\x1', '\x2', '!', '\"', '\a', '\a', '\x2', '\x2', '\"', 
		'#', '\x5', '\b', '\x5', '\x2', '#', '$', '\a', '\b', '\x2', '\x2', '$', 
		';', '\x3', '\x2', '\x2', '\x2', '%', '&', '\a', '\f', '\x2', '\x2', '&', 
		'*', '\a', '\a', '\x2', '\x2', '\'', ')', '\x5', '\b', '\x5', '\x2', '(', 
		'\'', '\x3', '\x2', '\x2', '\x2', ')', ',', '\x3', '\x2', '\x2', '\x2', 
		'*', '(', '\x3', '\x2', '\x2', '\x2', '*', '+', '\x3', '\x2', '\x2', '\x2', 
		'+', '-', '\x3', '\x2', '\x2', '\x2', ',', '*', '\x3', '\x2', '\x2', '\x2', 
		'-', ';', '\a', '\b', '\x2', '\x2', '.', '\x32', '\a', '\a', '\x2', '\x2', 
		'/', '\x31', '\x5', '\x6', '\x4', '\x2', '\x30', '/', '\x3', '\x2', '\x2', 
		'\x2', '\x31', '\x34', '\x3', '\x2', '\x2', '\x2', '\x32', '\x30', '\x3', 
		'\x2', '\x2', '\x2', '\x32', '\x33', '\x3', '\x2', '\x2', '\x2', '\x33', 
		'\x35', '\x3', '\x2', '\x2', '\x2', '\x34', '\x32', '\x3', '\x2', '\x2', 
		'\x2', '\x35', '\x36', '\a', '\b', '\x2', '\x2', '\x36', '\x37', '\a', 
		'\t', '\x2', '\x2', '\x37', ';', '\x5', '\b', '\x5', '\x5', '\x38', ';', 
		'\a', '\x11', '\x2', '\x2', '\x39', ';', '\a', '\f', '\x2', '\x2', ':', 
		' ', '\x3', '\x2', '\x2', '\x2', ':', '%', '\x3', '\x2', '\x2', '\x2', 
		':', '.', '\x3', '\x2', '\x2', '\x2', ':', '\x38', '\x3', '\x2', '\x2', 
		'\x2', ':', '\x39', '\x3', '\x2', '\x2', '\x2', ';', '\x44', '\x3', '\x2', 
		'\x2', '\x2', '<', '=', '\f', '\b', '\x2', '\x2', '=', '>', '\t', '\x2', 
		'\x2', '\x2', '>', '\x43', '\x5', '\b', '\x5', '\t', '?', '@', '\f', '\a', 
		'\x2', '\x2', '@', '\x41', '\t', '\x3', '\x2', '\x2', '\x41', '\x43', 
		'\x5', '\b', '\x5', '\b', '\x42', '<', '\x3', '\x2', '\x2', '\x2', '\x42', 
		'?', '\x3', '\x2', '\x2', '\x2', '\x43', '\x46', '\x3', '\x2', '\x2', 
		'\x2', '\x44', '\x42', '\x3', '\x2', '\x2', '\x2', '\x44', '\x45', '\x3', 
		'\x2', '\x2', '\x2', '\x45', '\t', '\x3', '\x2', '\x2', '\x2', '\x46', 
		'\x44', '\x3', '\x2', '\x2', '\x2', 'G', 'H', '\a', '\f', '\x2', '\x2', 
		'H', 'I', '\a', '\n', '\x2', '\x2', 'I', 'J', '\x5', '\f', '\a', '\x2', 
		'J', '\v', '\x3', '\x2', '\x2', '\x2', 'K', 'L', '\b', '\a', '\x1', '\x2', 
		'L', 'N', '\a', '\a', '\x2', '\x2', 'M', 'O', '\x5', '\f', '\a', '\x2', 
		'N', 'M', '\x3', '\x2', '\x2', '\x2', 'O', 'P', '\x3', '\x2', '\x2', '\x2', 
		'P', 'N', '\x3', '\x2', '\x2', '\x2', 'P', 'Q', '\x3', '\x2', '\x2', '\x2', 
		'Q', 'R', '\x3', '\x2', '\x2', '\x2', 'R', 'S', '\a', '\b', '\x2', '\x2', 
		'S', 'V', '\x3', '\x2', '\x2', '\x2', 'T', 'V', '\a', '\f', '\x2', '\x2', 
		'U', 'K', '\x3', '\x2', '\x2', '\x2', 'U', 'T', '\x3', '\x2', '\x2', '\x2', 
		'V', '_', '\x3', '\x2', '\x2', '\x2', 'W', 'X', '\f', '\x5', '\x2', '\x2', 
		'X', 'Y', '\a', '\v', '\x2', '\x2', 'Y', '^', '\x5', '\f', '\a', '\x6', 
		'Z', '[', '\f', '\x4', '\x2', '\x2', '[', '\\', '\a', '\t', '\x2', '\x2', 
		'\\', '^', '\x5', '\f', '\a', '\x5', ']', 'W', '\x3', '\x2', '\x2', '\x2', 
		']', 'Z', '\x3', '\x2', '\x2', '\x2', '^', '\x61', '\x3', '\x2', '\x2', 
		'\x2', '_', ']', '\x3', '\x2', '\x2', '\x2', '_', '`', '\x3', '\x2', '\x2', 
		'\x2', '`', '\r', '\x3', '\x2', '\x2', '\x2', '\x61', '_', '\x3', '\x2', 
		'\x2', '\x2', '\r', '\x12', '\x14', '*', '\x32', ':', '\x42', '\x44', 
		'P', 'U', ']', '_',
	};

	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN);


}
} // namespace Sane.Grammar
