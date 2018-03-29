using System;
using System.Collections.Generic;

namespace testAllTime
{
    class Program
    {
        private static bool checkPalindrom(long first, long second)
        {
            long digit = first * second;
            string pars_int = Convert.ToString(digit);
            for (int a = 0, b = pars_int.Length - 1; a != pars_int.Length / 2; a++, b--)
            {
                if (pars_int[a] != pars_int[b])
                {
                    return false;
                }
            }
            return true;
        }

        public static void Fill_SimplDigit(List<int> simplDigit, int n1 = 10000, int n2 = 99999)
        {
            bool flag;
            for (int i = n1; i <= n2; i++)
            {
                flag = i % 2 != 0 || i == 2;
                for (int j = 3; flag && j * j <= i; j += 2)
                    flag = i % j != 0;
                if (flag)
                    simplDigit.Add(i);
            }
        }

        public static void Possibility_Palindrom(List<int> simplDigit)
        {
            bool isPalindrom = false;
            int firstPrarameter = 0, secondParameter = 0;
            long result = 0;

            for (int i = simplDigit.Count - 1; i != 1; i--)
            {
                for (int j = 0; j !=simplDigit.Count-1; ++j )
                {
                    isPalindrom = checkPalindrom(simplDigit[i], simplDigit[j]);
                    if (isPalindrom == true)
                    {
                        if (result < (simplDigit[i] * simplDigit[j]))
                        {
                            firstPrarameter = simplDigit[i];
                            secondParameter = simplDigit[j];
                            result = firstPrarameter * secondParameter;
                        }
                    }
                }
                simplDigit.RemoveAt(i);
            }
            Console.WriteLine($"{result}  {firstPrarameter} { secondParameter} {simplDigit.Count} ");
        }

       
        static void Main(string[] args)
        {
            DateTime tmN = DateTime.Now;
            List<int> SimplDigit = new List<int>();//for simpl digit
            Fill_SimplDigit(SimplDigit);
            Possibility_Palindrom(SimplDigit);

            TimeSpan tt = DateTime.Now - tmN;
            Console.WriteLine(tt.ToString());
        }
    }
}
