using DSharp.Dom.Statements;

namespace DSharp.Dom
{
	public interface StaticStatement : IStatement
	{
		DAttribute[] Attributes { get; set; }
	}	
}
