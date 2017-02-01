
using CompilerNamespace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompilerTester
{
    
    class Program
    {
        public static string Chars = "abcdefghijklmnopqrstuv1234567890=-+*/;',.?&() ";
        static void Main(string[] args)
        {
            Console.WriteLine(Compiler.Compile("              int                       a     =                        3        ;"));
            //Console.WriteLine(Compiler.Compile("bla"));
            Console.WriteLine(String.Format("This one compiled: {0}", GetCorrectRandomLine()));
        }

        static string GetCorrectRandomLine()
        {
            Random r = new Random();
            int minChars = 4;
            string last = "";
            bool compiled = false;
            double counter = 0;
            while (!compiled)
            {
                last = "";
                for (int i = 0; i < 2*minChars; i++)
                {
                    char nextChar = Chars[r.Next(Chars.Length)];
                    last += nextChar;
                }
                compiled = Compiler.Compile(last);
                Console.WriteLine(counter+++":"+last);
            }
            Console.WriteLine("**********************BAZINGA*******************************:" + last);
            return last;

        }
    }
}
