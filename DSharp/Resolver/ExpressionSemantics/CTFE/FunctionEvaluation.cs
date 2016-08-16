using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DSharp.Dom;
using DSharp.Dom.Expressions;
using DSharp.Resolver.ExpressionSemantics;

namespace DSharp.Resolver.ExpressionSemantics.CTFE
{
	public class FunctionEvaluation
	{
		public static ISymbolValue Execute(MemberSymbol method, ISymbolValue[] arguments, AbstractSymbolValueProvider vp)
		{
			return new ErrorValue(new EvaluationException("CTFE пока ещё не реализован."));
		}
	}
}
