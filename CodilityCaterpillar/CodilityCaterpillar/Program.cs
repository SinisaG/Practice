using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 
 
 
 
 */

namespace CodilityCaterpillar
{
    class Program
    {
        static void Main(string[] args)
        {
            var A =new int [] {6, 2, 7, 4, 1, 3, 6};
            var limit = 13;
            Console.WriteLine(Cat(A,limit));
            Console.Read();
        }


        public static bool Cat(int[] A, int limit)
        {
            int front = 0;
            int total = 0;
            for (int back = 0; back < A.Length; back++)
            {
                while (front < A.Length && A[front] + total <= limit)
                {
                    total = total + A[front];
                    front++;
                }
                if (total == limit)
                    return true;
                total = total - A[back];
            }
            return false;
        }
    }
}
