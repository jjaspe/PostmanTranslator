using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAmBecomeDeathDestroyerOfWorlds
{
    public class Compiler
    {
        static string intDeclaration = "int [a-zA-z].* = \\d*;";
        static string intSmall = "int ";

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
            return Check(text, intDeclaration)
                || Check(text, intSmall);
        }
    }
}
