using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LargestPrimeFactor
{
    class Program
    {
        public static Random rnd = new Random();
        static void Main(string[] args)
        {
            var r = FindAllFactors(600851475143);
            foreach (var factor in r)
            {
                Console.WriteLine(factor);
            }

            Console.Read();

        }

        public static bool IsPrime(long n)
        {
            if (n%2 == 0)
                return false;
            for (int i = 2; i < Math.Ceiling(Math.Sqrt(n)); i++)
            {
                if (n%i == 0)
                    return false;
            }
            return true;
        }

        public static List<long> FindAllFactors(long n)
        {
            var result = new List<long>();
            while (!IsPrime(n))
            {
                var factor = FindFactor(n);
                result.Add(factor);
                n = n/factor;
            }
            result.Add(n);
            return result;
        }

        public static long FindFactor(long n)
        {
            long x;
            long y;
            long d = 1;
            while (d == 1)
            {
                x = rnd.Next(1,(int) Math.Sqrt(n));
                y = rnd.Next(1, (int)Math.Sqrt(n));
                if(x!=y)
                    d = GCD(Math.Abs(x-y), n);
                if (d != 1 && !IsPrime(d))
                    d = 1;
            }
            return d;
        }

        public static long GCD(long a, long b)
        {
            var max = Math.Max(a, b);
            var min = Math.Min(a, b);
            var modulo = max%min;
            if ( modulo== 0)
            {
                return min;
            }
            else
            {
                return GCD(min, modulo);
            }
        }
    }
}
