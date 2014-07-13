using System;

namespace EvenFibonacciNumbers
{
    class Program
    {
        public static double GoldenRatio = ((1 + Math.Sqrt(5)) / 2);
        static void Main(string[] args)
        {

            int limit = 4000000;
            FibonacciFast(limit);
            Fibonacci(1,1, 0, limit);
            Console.Read();
        }

        public static void Fibonacci(int fib, int sum, int result, int limit)
        {
            if (sum >= limit){
                Console.WriteLine(result);
                return;
            }
            if (sum%2 == 0)
                result = result + sum;
            Fibonacci(sum, sum+fib, result, limit);
        }

        public static void FibonacciFast(int limit)
        {
            //Binet's rearranged formula, result devided by 3 and round down, to get number of even numbers
            var k =(int)(Math.Log((limit*Math.Sqrt(5) + Math.Sqrt(5*Math.Pow(limit,2) - 4))/2, GoldenRatio)/3);
            
            //calculate some constants to make the final expression a bit easier to read
            var goldenRationPower3 = Math.Pow(GoldenRatio, 3);
            var goldenRationPowerMinus3 = Math.Pow(GoldenRatio, -3);
            var goldenRationPower3PowerK = Math.Pow(goldenRationPower3, k);
            var goldenRationPowerMinus3PowerK = Math.Pow(goldenRationPowerMinus3, k);
            // sum of our two geometric series 
            var result = ((goldenRationPower3 * ((1-goldenRationPower3PowerK)/(1-goldenRationPower3))) + (goldenRationPowerMinus3 * ((1 - (-goldenRationPowerMinus3PowerK))/(1+goldenRationPowerMinus3))))/Math.Sqrt(5);
            //outprint result
            Console.WriteLine((int)result);
        }

        public static int Fibonacci(int number)
        {
            if (number <= 1)
            {
                return 1;
            }
            else
            {
                return Fibonacci(number - 2) + Fibonacci(number - 1);
            }
        }
    }
}
