using System;
using BinaryTree.Model;

namespace BinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
            var tree = new BST();
            tree.Insert(15);
            tree.Insert(10);
            tree.Insert(20);
            tree.Insert(25);
            tree.Insert(8);
            tree.Insert(12);
            tree.Insert(11);
            tree.Delete(20);
            Console.WriteLine();
            tree.Print();
            Console.ReadLine();
        }
    }
}
