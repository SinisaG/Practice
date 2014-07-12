using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;



namespace EulerProject.PrimePermutation049
{

/*
    The arithmetic sequence, 1487, 4817, 8147, in which each of the terms increases by 3330, is unusual in two ways: (i) each of the three terms are prime, and, (ii) each of the 4-digit numbers are permutations of one another.
    There are no arithmetic sequences made up of three 1-, 2-, or 3-digit primes, exhibiting this property, but there is one other 4-digit increasing sequence.
    What 12-digit number do you form by concatenating the three terms in this sequence?
*/
//What we know is that we have to do the check only for primes, numbers are 4 digits and permutations.
//We dont know the right k, so we have to check for all of them that are sufficient for upper conditions

    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 1000; i < 10000; i++)
            {
                if (IsPrime(i))
                {
                    int k = 1;
                    while (i + 2 * k < 10000)
                    {
                        if (IsPrime(i + k) && IsPerm(i, i + k))
                        {
                            if (IsPrime(i + 2 * k) && IsPerm(i, i + 2 * k) && IsPerm(i + k, i + 2 * k))
                            {
                                Console.WriteLine("Got it!");
                                Console.WriteLine("Sequence is {0}, {1}, {2}", i, i + k, i + 2 * k);
                                Console.WriteLine("Increasing factor is " + k);
                                Console.WriteLine("-------------------------");
                            }
                        }
                        k++;
                    }
                }
            }
            Console.Read();
            //we get 2 results, one that is in task description and second one, that we are looking for: 296962999629
        }
        //numbers can not be equal, so we dont have to check for that
        public static bool IsPerm(int a, int b)
        {
            var tempA = a.ToString();
            var tempB = b.ToString();
            var dict = new Dictionary<char, int>();
            for (int i = 0; i < tempA.Count(); i++)
            {
                if (dict.ContainsKey(tempA[i]))
                    dict[tempA[i]] = dict[tempA[i]] + 1;
                else
                {
                    dict[tempA[i]] = 1;
                }
            }

            for (int i = 0; i < tempB.Count(); i++)
            {
                if (!dict.ContainsKey(tempB[i]) || dict[tempB[i]] == 0)
                    return false;
                else
                {
                    dict[tempB[i]] = dict[tempB[i]] - 1;
                }
            }
            return true;
        }

        public static bool IsPrime(int a)
        {
            if (a % 2 == 0)
                return false;
            for (int i = 2; i <= (int)Math.Sqrt(a); i++)
            {
                if (a % i == 0)
                    return false;
            }
            return true;
        }
    }
}
