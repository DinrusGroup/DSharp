using System.Collections.Generic;
using DSharp.Dom;
using DSharp.Parser;

namespace DSharp.Completion
{
	class ModuleStatementCompletionProvider : AbstractCompletionProvider
	{
		public ModuleStatementCompletionProvider(ICompletionDataGenerator dg) : base(dg){}
		
		protected override void BuildCompletionDataInternal(IEditorData Editor, char enteredChar)
		{
			CompletionDataGenerator.AddModule(Editor.SyntaxTree);
		}
	}
}
