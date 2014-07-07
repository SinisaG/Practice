using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FileToTree
{
    class Program
    {
        static void Main(string[] args)
        {
            var tree = new BST();
            using (StreamReader sr = new StreamReader("Input.txt"))
            {
                var line = sr.ReadLine();
                while (line != null)
                {
                    tree.Insert(line);
                    line = sr.ReadLine();
                }
              
            }
            Console.WriteLine(tree.LSearch("abececa"));
            tree.Print();   
            Console.Read();
        }
    }
}
