using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace RegEx
{
    class Program
    {
        static void Main(string[] args)
        {
            //find case insensitive substring with regex
            Console.Write("Substring:");
            var substring = Console.ReadLine();
            Console.Write("Text:");
            var text = Console.ReadLine();
            var regSubstring = "(?i)" + substring + "(?-i)";
            var reg = new Regex(regSubstring);

            var state = reg.Match(text);
            if (state.Success)
            {
                Console.WriteLine("{0} found in text starting at index {1}", substring, state.Index);
            }
            else
            {
                Console.WriteLine("Substring not found");
            }
            Console.Read();
        }
    }
}
