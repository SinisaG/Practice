using System;
using System.Diagnostics;

namespace Multiples3and5
{
    class Program
    {
        static void Main(string[] args)
        {
            int limit = 1000000000;
            Console.WriteLine(SlowSumMultiples(limit));
            Console.WriteLine(FastSumMultiples(limit));
            Console.Read();
        }

        public static long SlowSumMultiples(int limit)
        {
            var watch = new Stopwatch();
            watch.Start();
            long sum = 0;
            for (int i = 2; i < limit; i++)
            {
                if (i%3 == 0 || i%5 == 0)
                {
                    sum = sum + i;
                }
            }
            watch.Stop();
            Console.WriteLine(watch.ElapsedMilliseconds);
            return sum;
        }

        public static long FastSumMultiples(int limit)
        {
            var watch = new Stopwatch();
            watch.Start();

            long three = limit%3 == 0 ? limit/3 - 1 : limit/3;
            long five = limit % 5 == 0 ? limit / 5 - 1 : limit / 5;
            long doubleElements = limit % 15 == 0 ? limit / 15 - 1 : limit / 15;

            long firstThree = 3;
            long lastThree = firstThree + (three - 1)*3;
            long firstFive = 5;
            long lastFive = firstFive + (five - 1)*5;
            long firstDouble = 15;
            long lastDouble = firstDouble + (doubleElements - 1)*15;

            long result = (three*(firstThree + lastThree)/2) + (five*(firstFive + lastFive)/2) -
                   (doubleElements*(firstDouble + lastDouble)/2);
            watch.Stop();
            Console.WriteLine(watch.ElapsedMilliseconds);
            return result;
        }
    }
}
