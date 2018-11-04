using System;
using System.Collections.Generic;

namespace Problem24
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());
            List<int> combinations = new List<int>();
            Comb(k, n);
            void Comb(int countOfElementsNeeded, int countOfTotalElements)
            {
                if (combinations.Count >= countOfElementsNeeded)
                {
                    Console.WriteLine(string.Join(" ", combinations));
                }
                else
                {
                    for (int i = 1; i <= countOfTotalElements; i++)
                    {
                        if (!combinations.Contains(i))
                        {
                            combinations.Add(i);
                            Comb(countOfElementsNeeded, countOfTotalElements);
                            combinations.Remove(i);
                        }

                    }
                }
            }


        }
    }
}
