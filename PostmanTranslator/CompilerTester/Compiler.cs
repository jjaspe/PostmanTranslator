using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompilerNamespace
{
    public class Compiler
    {
        static string numericDeclaration = "[a-zA-z][a-zA-Z0-9]* *= *\\d+ *;";
        public static List<string> Types = new List<string>() { "int", "long", "double", "short" };

        public static bool Check(string text,string pattern)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(text, pattern);
        }
        public static bool Compile(string text)
        {
            return IsDeclarartion(text);
        }

        public static bool IsDeclarartion(string text)
        {
            return Check(text, numericDeclaration);
        }
    }
}
