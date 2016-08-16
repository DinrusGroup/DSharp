using System.Collections.Generic;
using DSharp.Dom.Statements;
using DSharp.Resolver;
using DSharp.Resolver.TypeResolution;
using DSharp.Dom.Expressions;
using DSharp.Resolver.ExpressionSemantics;
using DSharp.Dom;

namespace DSharp.Completion
{
	/// <summary>
	/// Encapsules tooltip content.
	/// If there are more than one tooltip contents, there are more than one resolve results
	/// </summary>
	public class AbstractTooltipContent
	{
		public ISemantic ResolveResult;
		public string Title;
		public string Description;
	}

	public class AbstractTooltipProvider
	{
		public static List<AbstractTooltipContent> BuildToolTip(IEditorData Editor)
		{
			DResolver.NodeResolutionAttempt att;
			var rr = DResolver.ResolveTypeLoosely(Editor, out att);

			if (rr == null || rr.Length < 1)
				return null;

			var l = new List<AbstractTooltipContent>();
			foreach (var res in rr)
				l.Add(BuildTooltipContent(res));

			return l;
		}

		static AbstractTooltipContent BuildTooltipContent(ISemantic res)
		{
			if (res is ISymbolValue) {
				var sv = res as ISymbolValue;

				if (sv is TypeValue)
					return new AbstractTooltipContent { ResolveResult = res, Title = sv.RepresentedType.ToString() };

				return new AbstractTooltipContent { 
					ResolveResult = res,
					Title = "(" + sv.RepresentedType + ") "+sv.ToCode()
				};
			}

			// Only show one description for items sharing descriptions
			string description = res is DSymbol ? ((DSymbol)res).Definition.Description : "";

			return new AbstractTooltipContent
			{
				ResolveResult = res,
				Title = (res is ModuleSymbol ? ((ModuleSymbol)res).Definition.FileName : res.ToString()),
				Description = description
			};
		}
	}
}
