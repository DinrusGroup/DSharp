using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using DSharp.Dom;
using DSharp.Dom.Expressions;
using DSharp.Dom.Statements;
using System;

namespace DSharp.Parser
{
    /// <summary>
    /// Парсер кода D
    /// </summary>
    public partial class DParser:DTokens, IDisposable
	{
		#region Properties
		/// <summary>
		/// Содержит структуру документа
		/// </summary>
		DModule doc;

		public DModule Document
		{
			get { return doc; }
		}

		/// <summary>
		/// Модификаторы для всего блока
		/// </summary>
		Stack<DAttribute> BlockAttributes = new Stack<DAttribute>();
		/// <summary>
		/// Модификаторы только для текущего выражения
		/// </summary>
		Stack<DAttribute> DeclarationAttributes = new Stack<DAttribute>();

		bool ParseStructureOnly = false;
		public Lexer Lexer;

		/// <summary>
		/// Используется для трэкинга выражения/декларации/инструкции/всего, что в данный момент обрабатывается.
		/// Необходим для комплектации кода.
		/// </summary>
		public object LastParsedObject
		{ 
			get { return TrackerVariables.LastParsedObject; } 
			set { TrackerVariables.LastParsedObject = value; }
		}

		/// <summary>
		/// Необходим для комплектации кода.
		/// True, если ожидается идентификатор типа/переменной/метода/и т.д.
		/// </summary>
		public bool ExpectingNodeName { set { TrackerVariables.ExpectingNodeName = value; } get { return TrackerVariables.ExpectingNodeName; } }

		public ParserTrackerVariables TrackerVariables = new ParserTrackerVariables();

		DToken _backupt = new DToken();
		DToken t
		{
			[System.Diagnostics.DebuggerStepThrough]
			get
			{
				return Lexer.CurrentToken ?? _backupt;
			}
		}

		/// <summary>
		/// lookAhead токен
		/// </summary>
		DToken la
		{
			get
			{
				return Lexer.LookAhead;
			}
		}
		
		byte laKind {get{return Lexer.laKind;}}

		bool IsEOF
		{
			get { return Lexer.IsEOF; }
		}

		public List<ParserError> ParseErrors = new List<ParserError>();
		public const int MaxParseErrorsBeforeFailure = 100;
		#endregion

		public void Dispose()
		{
			doc = null;
			BlockAttributes.Clear();
			BlockAttributes = null;
			DeclarationAttributes.Clear();
			DeclarationAttributes = null;
			Lexer.Dispose();
			Lexer = null;
			TrackerVariables = null;
			ParseErrors = null;
		}

		public DParser(Lexer lexer)
		{
			this.Lexer = lexer;
			Lexer.LexerErrors = ParseErrors;
		}

		#region External interface
		/// <summary>
		/// Находит последнюю инструкцию import и возвращает ее крайнюю позицию (после точки с запятой).
		/// Если инструкций import не обнаружено, а только module, будет возвращено крайнее положение этого module.
		/// </summary>
		public static CodeLocation FindLastImportStatementEndLocation(DModule m, string moduleCode = null)
		{
			IStatement lastStmt = null;

			foreach (var s in m.StaticStatements)
				if (s is ImportStatement)
					lastStmt = s;
				else if (lastStmt != null)
					break;

			if (lastStmt != null)
				return lastStmt.EndLocation;

			if (m.OptionalModuleStatement != null)
				return m.OptionalModuleStatement.EndLocation;

			if (moduleCode != null)
				using(var sr = new StringReader(moduleCode))
				using (var lx = new Lexer(sr) { OnlyEnlistDDocComments = false })
				{
					lx.NextToken();

					if (lx.Comments.Count != 0)
						return lx.Comments[lx.Comments.Count - 1].EndPosition;
				}

			return new CodeLocation(1, 1);
		}

		public static BlockStatement ParseBlockStatement(string Code, INode ParentNode = null)
		{
			return ParseBlockStatement(Code, CodeLocation.Empty, ParentNode);
		}

		public static BlockStatement ParseBlockStatement(string Code, CodeLocation initialLocation, INode ParentNode = null)
		{
			var p = Create(new StringReader(Code));
			p.Lexer.SetInitialLocation(initialLocation);
			p.Step();

			return p.BlockStatement(ParentNode);
		}

        public static IExpression ParseExpression(string Code)
        {
            var p = Create(new StringReader(Code));
            p.Step();
            return p.Expression();
        }

		public static IExpression ParseAssignExpression(string Code)
		{
			var p = Create(new StringReader(Code));
			p.Step();
			return p.AssignExpression();
		}

        public static ITypeDeclaration ParseBasicType(string Code,out DToken OptionalToken)
        {
            OptionalToken = null;

            var p = Create(new StringReader(Code));
            p.Step();
            // Exception: If we haven't got any basic types as our first token, return this token via OptionalToken
            if (!p.IsBasicType() || p.laKind == __LINE__ || p.laKind == __FILE__)
            {
                p.Step();
                p.Peek(1);
                OptionalToken = p.t;

                // Only if a dot follows a 'this' or 'super' token we go on parsing; Return otherwise
                if (!((p.t.Kind == This || p.t.Kind == Super) && p.laKind == Dot))
                    return null;
            }
            
            var bt= p.BasicType();
            while (p.IsBasicType2())
            {
                var bt2 = p.BasicType2();
                bt2.InnerMost = bt;
                bt = bt2;
            }
            return bt;
        }

        public static DModule ParseString(string ModuleCode,bool SkipFunctionBodies=false, bool KeepComments = true)
        {
            using(var sr = new StringReader(ModuleCode))
        	{
            	using(var p = Create(sr))
            		return p.Parse(SkipFunctionBodies, KeepComments);
        	}
        }

        public static DModule ParseFile(string File, bool SkipFunctionBodies=false, bool KeepComments = true)
        {
        	using(var s = new StreamReader(File)){
	            var p=Create(s);
	            var m = p.Parse(SkipFunctionBodies, KeepComments);
	            m.FileName = File;
	            if(string.IsNullOrEmpty(m.ModuleName))
					m.ModuleName = Path.GetFileNameWithoutExtension(File);
				s.Close();
				return m;
        	}
        }
        
        public static DMethod ParseMethodDeclarationHeader(string headerCode, out ITypeDeclaration identifierChain)
        {
        	using(var sr = new StringReader(headerCode))
        	{
	            var p = Create(sr);
	            p.Step();
	            
	            var n = new DMethod();
	            p.CheckForStorageClasses(p.doc);
	            p.ApplyAttributes(n);
	            p.FunctionAttributes(n);
	            
	            n.Type = p.Type();
	            
	            identifierChain = p.IdentifierList();
	            if(identifierChain is IdentifierDeclaration)
					n.NameHash = (identifierChain as IdentifierDeclaration).IdHash;
	            
	            n.Parameters = p.Parameters(n);
	            
	            return n;
        	}
        }

        /// <summary>
        /// Заново разбирает модуль
        /// </summary>
        /// <param name="Module"></param>
        public static void UpdateModule(DModule Module)
        {
            var m = DParser.ParseFile(Module.FileName);
			Module.ParseErrors = m.ParseErrors;
            Module.AssignFrom(m);
        }

        public static void UpdateModuleFromText(DModule Module, string Code)
        {
            var m = DParser.ParseString(Code);
			Module.ParseErrors = m.ParseErrors;
            Module.AssignFrom(m);
        }

        public static DParser Create(TextReader tr)
        {
			return new DParser(new Lexer(tr));
        }
		#endregion

		void PushAttribute(DAttribute attr, bool BlockAttributes)
		{
			var stk=BlockAttributes?this.BlockAttributes:this.DeclarationAttributes;

			var m = attr as Modifier;
			if(m!=null)
			// If attr would change the accessability of an item, remove all previously found (so the most near attribute that's next to the item is significant)
			if (DTokens.VisModifiers[m.Token])
				Modifier.CleanupAccessorAttributes(stk, m.Token);
			else
				Modifier.RemoveFromStack(stk, m.Token);

			stk.Push(attr);
		}

        void ApplyAttributes(DNode n)
        {
        	n.Attributes = GetCurrentAttributeSet();
        }
        
        DAttribute[] GetCurrentAttributeSet_Array()
        {
        	var attrs = GetCurrentAttributeSet();
        	return attrs.Count == 0 ? null : attrs.ToArray();
        }
        
        List<DAttribute> GetCurrentAttributeSet()
        {
        	var attrs = new List<DAttribute>();
			foreach (var attr in BlockAttributes.ToArray())
					attrs.Add(attr);

            while (DeclarationAttributes.Count > 0)
            {
                var attr = DeclarationAttributes.Pop();

				var m = attr as Modifier;
				if (m != null)
				{
					// If accessor already in attribute array, remove it
					if (DTokens.VisModifiers[m.Token])
						Modifier.CleanupAccessorAttributes(attrs);

					if (!Modifier.ContainsAttribute(attrs, m.Token))
						attrs.Add(attr);
				}
				else
					attrs.Add(attr);
            }
            
            return attrs;
        }

        void OverPeekBrackets(byte OpenBracketKind,bool LAIsOpenBracket = false)
        {
            int CloseBracket = CloseParenthesis;

            if (OpenBracketKind == OpenSquareBracket) 
				CloseBracket = CloseSquareBracket;
            else if (OpenBracketKind == OpenCurlyBrace) 
				CloseBracket = CloseCurlyBrace;

			var pk = Lexer.CurrentPeekToken;
            int i = LAIsOpenBracket?1:0;
            while (pk.Kind != EOF)
            {
                if (pk.Kind== OpenBracketKind)
                    i++;
                else if (pk.Kind== CloseBracket)
                {
                    i--;
                    if (i <= 0) 
					{ 
						Peek(); 
						break; 
					}
                }
                pk = Peek();
            }
        }

        private bool Expect(byte n)
        {
			if (laKind == n)
			{
				Step();
				return true; 
			}
			else
			{
				if (n == Identifier && IsEOF)
					TrackerVariables.ExpectingIdentifier = true;
				SynErr(n, DTokens.GetTokenString(n) + " ожидалось, "+DTokens.GetTokenString(laKind)+" обнаружено!");
			}
            return false;
        }

        /// <summary>
        /// Получает строковое значение текущего токена
        /// </summary>
        protected string strVal
        {
            get
            {
                if (t.Kind == DTokens.Identifier || t.Kind == DTokens.Literal)
                    return t.Value;
                return DTokens.GetTokenString(t.Kind);
            }
        }

        DToken Peek()
        {
            return Lexer.Peek();
        }

        DToken Peek(int n)
        {
            Lexer.StartPeek();
            DToken x = la;
            while (n > 0)
            {
                x = Lexer.Peek();
                n--;
            }
            return x;
        }

		public void Step()
		{ 
			Lexer.NextToken();
		}

        [DebuggerStepThrough()]
        public DModule Parse()
        {
            return Parse(false);
        }

        /// <summary>
        /// Инициализует и проводит процедуру разбора (парсинга)
        /// </summary>
        /// <param name="imports">Список импортов в модуле</param>
        /// <param name="ParseStructureOnly">Если true, все инструкции и не-декларации игнорируются - это полезно для анализа библиотек</param>
        /// <returns>Полностью парсированную структуру модуля</returns>
        public DModule Parse(bool ParseStructureOnly, bool KeepComments = true)
        {
            this.ParseStructureOnly = ParseStructureOnly;
            if(KeepComments)
            	Lexer.OnlyEnlistDDocComments = false;
            doc=Root();
			doc.ParseErrors = new System.Collections.ObjectModel.ReadOnlyCollection<ParserError>(ParseErrors);
			if(KeepComments){
				doc.Comments = TrackerVariables.Comments.ToArray();
			}
			
            return doc;
        }
        
        #region Error handlers
        void SynErr(byte n, string msg)
        {
			if (ParseErrors.Count > MaxParseErrorsBeforeFailure)
			{
				return;
				throw new TooManyErrorsException();
			}
			else if (ParseErrors.Count == MaxParseErrorsBeforeFailure)
				msg = "Слишком много ошибок - разбор остановлен";

			ParseErrors.Add(new ParserError(false,msg,n,la.Location));
        }
        void SynErr(byte n)
		{
			SynErr(n, DTokens.GetTokenString(n) + " ожидалось" + (t!=null?(", "+DTokens.GetTokenString(t.Kind)+" обнаружено"):""));
        }

        void SemErr(byte n, string msg)
        {
			ParseErrors.Add(new ParserError(true, msg, n, la.Location));
        }
        /*void SemErr(int n)
        {
			ParseErrors.Add(new ParserError(true, DTokens.GetTokenString(n) + " expected" + (t != null ? (", " + DTokens.GetTokenString(t.Kind) + " found") : ""), n, t == null ? la.Location : t.EndLocation));
        }*/
        #endregion
	}

	public class TooManyErrorsException : Exception
	{
		public TooManyErrorsException() : base("Слишком много ошибок") { }
	}

	public class ParserTrackerVariables
	{
		/// <summary>
		/// Used to track the expression/declaration/statement/whatever which is handled currently.
		/// Required for code completion.
		/// </summary>
		public object LastParsedObject;

		public readonly List<Comment> Comments = new List<Comment>();

		/// <summary>
		/// Необходим для комплектации кода.
		/// True if a type/variable/method/etc. identifier is expected.
		/// </summary>
		public bool ExpectingNodeName;
		public bool ExpectingIdentifier;
		public bool IsParsingAssignExpression;

		public INode InitializedNode;
		public bool IsParsingInitializer;

		public bool IsParsingBaseClassList;
	}
}
