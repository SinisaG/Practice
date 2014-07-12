using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace EulerProject.StepNumbers178
{
    class Program
    {
        /*
Consider the number 45656. 
It can be seen that each pair of consecutive digits of 45656 has a difference of one.
A number for which every pair of consecutive digits has a difference of one is called a step number.
A pandigital number contains every decimal digit from 0 to 9 at least once.
How many pandigital step numbers less than 1040 are there?
         * */
/*Thinking:
 * we need at least 10 digit number to have a pandigital number. 
 * number doesnt start with zero
 */
        static void Main(string[] args)
        {
            var result = 0;
            for (long i = (long) Math.Pow(10, 10); i < Math.Pow(10, 40); i++)
            {
                if (StepNumber(i))
                {
                    if (IsPanDigital(i))
                    {
                        Console.WriteLine(i);
                        result++;
                    }
                }     
            }
           
            Console.Read();
        }
       
        public static bool StepNumber(long a)
        {
            var sa = a.ToString();

            for (int i = 0; i < sa.Count(); i++)
            {
                if (i == 0)
                {
                    var first = CharToInt(sa[0]);
                    var second = CharToInt(sa[1]);
                    if (Math.Abs(first - second) != 1)
                        return false;
                }
                else if (i == sa.Count()-1)
                {
                    var first = CharToInt(sa[sa.Count() - 1]);
                    var second = CharToInt(sa[sa.Count() - 2]);
                    if (Math.Abs(first - second) != 1)
                        return false;
                }
                else
                {
                    var current = CharToInt( sa[i]);
                    var left = CharToInt (sa[i - 1]);
                    var right = CharToInt(sa[i + 1]);
                    if (Math.Abs(left - current) != 1 || Math.Abs(right - current) != 1)
                        return false;
                }
            }
            return true;
        }


        public static bool IsPanDigital(long a)
        {
            var dict = new Dictionary<int, bool>();
            dict[0] = true;
            dict[1] = true;
            dict[2] = true;
            dict[3] = true;
            dict[4] = true;
            dict[5] = true;
            dict[6] = true;
            dict[7] = true;
            dict[8] = true;
            dict[9] = true;

            var sa = a.ToString();

            foreach (var digit in sa)
            {
                if (dict.ContainsKey(CharToInt(digit)))
                {
                    dict.Remove(CharToInt(digit));
                    if (dict.Count() == 0)
                        return true;
                }
            }
            return false;
        }

        public static int CharToInt(char c)
        {
            return c - '0';
        }
    }
}
