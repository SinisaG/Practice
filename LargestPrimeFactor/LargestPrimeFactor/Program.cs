using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace LargestPrimeFactor
{
    class Program
    {
        public static Random rnd = new Random();
        static void Main(string[] args)
        {
            var watch = new Stopwatch();
            watch.Start();
            long n = (long)int.MaxValue * (long) int.MaxValue;

            Console.WriteLine("Searching for " + n);
            Console.WriteLine("Fast Method");
            EasierMethod(n, new HashSet<long>());
            Console.WriteLine(watch.ElapsedMilliseconds);
            Console.WriteLine("Slow method");
            var r = FindAllFactors(n);
            foreach (var factor in r)
            {
                Console.WriteLine(factor);
            }
            
            watch.Stop();
            Console.WriteLine(watch.ElapsedMilliseconds);
            Console.Read();

        }

        public static bool IsPrime(long n)
        {
            if (n == 2)
                return true;
            if (n%2 == 0)
                return false;
            if (n%Math.Sqrt(n) == 0)
                return false;
            var limit = Math.Ceiling(Math.Sqrt(n)) + 1;
            for (int i = 2; i < limit; i++)
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
            //int limit = int.MaxValue < n ? int.MaxValue : (int)n;
            while (d == 1)
            {
                x = LongRandom(2,long.MaxValue, rnd);
                y = LongRandom(2, long.MaxValue, rnd);
 
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

        public static long LongRandom(long min, long max, Random rand)
        {
            byte[] buf = new byte[8];
            rand.NextBytes(buf);
            long longRand = BitConverter.ToInt64(buf, 0);

            return (Math.Abs(longRand % (max - min)) + min);
        }

        public static void EasierMethod(long n, HashSet<long> set )
        {
            var limit = Math.Ceiling(Math.Sqrt(n)) + 1;
            int prime=1;
            if (set.Contains(n))
            {
                Console.WriteLine(n);
            }
            else
            {
                for (int i = 2; i < limit; i++)
                {
                    if (n % i == 0)
                    {
                        Console.WriteLine(i);
                        set.Add(i);
                        prime = i;
                        break;
                    }
                }
            }
            if (prime == 1)
            {
                if (!set.Contains(n))
                    Console.WriteLine(n);
            }
            else
                EasierMethod(n / prime, set);
                
        }
    }
}
