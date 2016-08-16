using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DSharp.Dom.Expressions;
using DSharp.Parser;
using DSharp.Dom;
using DSharp.Resolver;
using DSharp.Resolver.TypeResolution;
using DSharp.Dom.Statements;
using DSharp.Resolver.Templates;

namespace DSharp.Resolver.ExpressionSemantics
{
	public partial class Evaluation
	{
		public ISemantic E(TypeidExpression tid)
		{
			//TODO: Split up into more detailed typeinfo objects (e.g. for arrays, pointers, classes etc.)

			if(!eval)
				return TypeDeclarationResolver.ResolveSingle(new IdentifierDeclaration("TypeInfo") { InnerDeclaration = new IdentifierDeclaration("object") }, ctxt);

			/*
			 * Depending on what's given as argument, it's needed to find out what kind of TypeInfo_ class to return
			 * AND to fill it with all required information.
			 * 
			 * http://dlang.org/phobos/object.html#TypeInfo
			 */
			throw new NotImplementedException("TypeInfo creation not supported yet");
		}
	}
}
