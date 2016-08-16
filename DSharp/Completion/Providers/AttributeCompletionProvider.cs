using System.Collections.Generic;
using DSharp.Dom;
using DSharp.Parser;

namespace DSharp.Completion.Providers
{
	class AttributeCompletionProvider : AbstractCompletionProvider
	{
		public DAttribute Attribute;

		public AttributeCompletionProvider(ICompletionDataGenerator gen) : base(gen) { }

		protected override void BuildCompletionDataInternal(IEditorData Editor, char enteredChar)
		{
			if (Attribute is VersionCondition)
			{
				foreach (var kv in new Dictionary<string, string>{
						{"DigitalMars","Используется компилятор DMD (Digital Mars D)"},
						{"GNU","Используется компилятор GDC (GNU D Compiler)"},
						{"LDC","Используется компилятор LDC (LLVM D Compiler)"},
						{"SDC","Используется компилятор SDC (Stupid D Compiler)"},
						{"D_NET","Используется компилятор D.NET"},
						{"Windows","Системы Microsoft Windows systems"},
						{"Win32","32-битные системы Microsoft Windows"},
						{"Win64","64-битные системы Microsoft Windows"},
						{"linux","Все системы Linux"},
						{"OSX","Mac OS X"},
						{"FreeBSD","FreeBSD"},
						{"OpenBSD","OpenBSD"},
						{"BSD","Все другие BSD"},
						{"Solaris","Solaris"},
						{"Posix","Все системы POSIX (включая Linux, FreeBSD, OS X, Solaris и т.д.)"},
						{"AIX","IBM Advanced Interactive eXecutive OS"},
						{"SkyOS","Операционная система SkyOS"},
						{"SysV3","Система V Выпуск 3"},
						{"SysV4","Система V Выпуск 4"},
						{"Hurd","GNU Hurd"},
						{"Cygwin","Среда Cygwin"},
						{"MinGW","Среда MinGW"},
						{"X86","Intel и AMD 32-битные процессоры"},
						{"X86_64","AMD и Intel 64-битные процессоры"},
						{"ARM","Продвинутая архитектура машины RISC (32-битная)"},
						{"PPC","Архитектура PowerPC, 32-битная"},
						{"PPC64","Архитектура PowerPC, 64-битная"},
						{"IA64","Архитектура Itanium (64-битная)"},
						{"MIPS","Архитектура MIPS, 32-битная"},
						{"MIPS64","Архитектура MIPS, 64-битная"},
						{"SPARC","Архитектура SPARC, 32-битная"},
						{"SPARC64","Архитектура SPARC, 64-битная"},
						{"S390","Архитектура System/390, 32-битная"},
						{"S390X","Архитектура System/390X, 64-битная"},
						{"HPPA","Архитектура HP PA-RISC, 32-битная"},
						{"HPPA64","Архитектура HP PA-RISC, 64-битная"},
						{"SH","Архитектура SuperH, 32-битная"},
						{"SH64","Архитектура SuperH, 64-битная"},
						{"Alpha","Архитектура Alpha"},
						{"LittleEndian","Порядок байт, наименее значимый первым"},
						{"BigEndian","Порядок байт, наиболее значимый первым"},
						{"D_Coverage","Code coverage analysis instrumentation (command line switch -cov) is being generated"},
						{"D_Ddoc","Ddoc documentation (command line switch -D) is being generated"},
						{"D_InlineAsm_X86","Inline assembler for X86 is implemented"},
						{"D_InlineAsm_X86_64","Inline assembler for X86-64 is implemented"},
						{"D_LP64","Pointers are 64 bits (command line switch -m64)"},
						{"D_PIC","Position Independent Code (command line switch -fPIC) is being generated"},
						{"D_SIMD","Vector Extensions are supported"},
						{"unittest","Unit tests are enabled (command line switch -unittest)"},
						{"D_Version2","This is a D version 2 compiler"},
						{"none","Never defined; used to just disable a section of code"},
						{"all","Always defined; used as the opposite of none"}
					})
					CompletionDataGenerator.AddTextItem(kv.Key, kv.Value);
			}
			else if (Attribute is PragmaAttribute)
			{
				var p = Attribute as PragmaAttribute;
				if (string.IsNullOrEmpty(p.Identifier))
					foreach (var kv in new Dictionary<string, string>{
					{"lib","Inserts a directive in the object file to link in"}, 
					{"msg","Prints a message while compiling"}, 
					{"startaddress","Puts a directive into the object file saying that the function specified in the first argument will be the start address for the program"}})
						CompletionDataGenerator.AddTextItem(kv.Key, kv.Value);
			}
			else if (Attribute is Modifier && ((Modifier)Attribute).Token == DTokens.Extern)
			{
				foreach (var kv in new Dictionary<string, string>{
					{"C",""},
					{"C++","C++ is reserved for future use"},
					{"D",""},
					{"Windows","Implementation Note: for Win32 platforms, Windows and Pascal should exist"},
					{"Pascal","Implementation Note: for Win32 platforms, Windows and Pascal should exist"},
					{"System","System is the same as Windows on Windows platforms, and C on other platforms"}
				})
					CompletionDataGenerator.AddTextItem(kv.Key, kv.Value);
			}
		}
	}

	internal class ScopeAttributeCompletionProvider : AbstractCompletionProvider
	{
		//public ScopeGuardStatement ScopeStmt;

		public ScopeAttributeCompletionProvider(ICompletionDataGenerator gen) : base(gen) { }

		protected override void BuildCompletionDataInternal(IEditorData Editor, char enteredChar)
		{
			foreach (var kv in new Dictionary<string, string>{
				{"exit","Выполняется при выходе из текущего масштаба"}, 
				{"success", "Выполняется, если в текущем масштабе не было ошибок при выполнении кода"}, 
				{"failure","Выполняется, если в текущем масштабе были ошибки при выполнении кода"}})
				CompletionDataGenerator.AddTextItem(kv.Key, kv.Value);
		}
	}

	internal class TraitsExpressionCompletionProvider : AbstractCompletionProvider
	{
		//public TraitsExpression TraitsExpr;

		public TraitsExpressionCompletionProvider(ICompletionDataGenerator gen) : base(gen) { }

		protected override void BuildCompletionDataInternal(IEditorData Editor, char enteredChar)
		{
			foreach (var kv in new Dictionary<string, string>{
				{"isArithmetic","If the arguments are all either types that are arithmetic types, or expressions that are typed as arithmetic types, then true is returned. Otherwise, false is returned. If there are no arguments, false is returned."},
				{"isFloating","Works like isArithmetic, except it's for floating point types (including imaginary and complex types)."},
				{"isIntegral","Works like isArithmetic, except it's for integral types (including character types)."},
				{"isScalar","Works like isArithmetic, except it's for scalar types."},
				{"isUnsigned","Works like isArithmetic, except it's for unsigned types."},
				{"isStaticArray","Works like isArithmetic, except it's for static array types."},
				{"isAssociativeArray","Works like isArithmetic, except it's for associative array types."},
				{"isAbstractClass","If the arguments are all either types that are abstract classes, or expressions that are typed as abstract classes, then true is returned. Otherwise, false is returned. If there are no arguments, false is returned."},
				{"isFinalClass","Works like isAbstractClass, except it's for final classes."},
				{"isVirtualFunction","The same as isVirtualMethod, except that final functions that don't override anything return true."},
				{"isVirtualMethod","Takes one argument. If that argument is a virtual function, true is returned, otherwise false. Final functions that don't override anything return false."},
				{"isAbstractFunction","Takes one argument. If that argument is an abstract function, true is returned, otherwise false."},
				{"isFinalFunction","Takes one argument. If that argument is a final function, true is returned, otherwise false."},
				{"isStaticFunction","Takes one argument. If that argument is a static function, meaning it has no context pointer, true is returned, otherwise false."},
				{"isRef","Takes one argument. If that argument is a declaration, true is returned if it is ref, otherwise false."},
				{"isOut","Takes one argument. If that argument is a declaration, true is returned if it is out, otherwise false."},
				{"isLazy","Takes one argument. If that argument is a declaration, true is returned if it is lazy, otherwise false."},
				{"hasMember","The first argument is a type that has members, or is an expression of a type that has members. The second argument is a string. If the string is a valid property of the type, true is returned, otherwise false."},
				{"identifier","Takes one argument, a symbol. Returns the identifier for that symbol as a string literal."},
				{"getMember","Takes two arguments, the second must be a string. The result is an expression formed from the first argument, followed by a ‘.’, followed by the second argument as an identifier."},
				{"getOverloads","The first argument is a class type or an expression of class type. The second argument is a string that matches the name of one of the functions of that class. The result is a tuple of all the overloads of that function."},
				{"getVirtualFunctions","The same as getVirtualMethods, except that final functions that do not override anything are included."},
				{"getVirtualMethods","The first argument is a class type or an expression of class type. The second argument is a string that matches the name of one of the functions of that class. The result is a tuple of the virtual overloads of that function. It does not include final functions that do not override anything."},
				{"parent","Takes a single argument which must evaluate to a symbol. The result is the symbol that is the parent of it."},
				{"classInstanceSize","Takes a single argument, which must evaluate to either a class type or an expression of class type. The result is of type size_t, and the value is the number of bytes in the runtime instance of the class type. It is based on the static type of a class, not the polymorphic type."},
				{"allMembers","Takes a single argument, which must evaluate to either a type or an expression of type. A tuple of string literals is returned, each of which is the name of a member of that type combined with all of the members of the base classes (if the type is a class). No name is repeated. Builtin properties are not included."},
				{"derivedMembers","Takes a single argument, which must evaluate to either a type or an expression of type. A tuple of string literals is returned, each of which is the name of a member of that type. No name is repeated. Base class member names are not included. Builtin properties are not included."},
				{"isSame","Takes two arguments and returns bool true if they are the same symbol, false if not."},
				{"compiles",@"Returns a bool true if all of the arguments compile (are semantically correct). The arguments can be symbols, types, or expressions that are syntactically correct. The arguments cannot be statements or declarations. If there are no arguments, the result is false."},
			})
				CompletionDataGenerator.AddTextItem(kv.Key, kv.Value);
		}
	}
}
