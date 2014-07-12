using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstUniqueIntInArray
{
    class Program
    {
        static void Main(string[] args)
        {
            var A = new int[] {1,1, 2, 3, 56, 4, 7, 4, 3, 2, 56, 1000};
            Console.WriteLine(FindFirstUnique(A));
            Console.Read();
        }

        public static int FindFirstUnique(int [] A)
        {
            var dict = new Dictionary<int, int>();
            var dict2 = new Dictionary<int, int>();
            int i = 0;
            foreach (var number in A)
            {
                if (dict.ContainsKey(number))
                {
                    dict2[number] = i;
                }
                else
                {
                    dict[number] = i;
                }
                i++;
            }

            int min = A.Count() + 1;
            foreach (var key in dict.Keys)
            {
                if (dict[key] < min && !dict2.ContainsKey(key))
                    min = dict[key];
            }
            return A[min];
        }

    }
}
