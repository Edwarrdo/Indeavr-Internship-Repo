using System;
using System.Numerics;

namespace Problem11
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int numbersToPrint = int.Parse(Console.ReadLine());
            BigInteger lastNumber = 0;
            BigInteger newNumber = 1;
            BigInteger beforeLastNumber;
            if (numbersToPrint == 0)
            {
            }
            else if (numbersToPrint == 1)
            {
                Console.WriteLine(lastNumber);
            }
            else if (numbersToPrint == 2)
            {
                Console.WriteLine($"{lastNumber}, {newNumber}");
            }
            else
            {
                Console.Write($"{lastNumber}, {newNumber}");

                for (int i = 2; i < numbersToPrint; i++)
                {
                    beforeLastNumber = lastNumber;
                    lastNumber = newNumber;
                    newNumber = beforeLastNumber + lastNumber;
                    if (i < numbersToPrint - 1)
                    {
                        Console.Write($"{newNumber}, ");
                    }
                    else
                    {
                        Console.WriteLine(newNumber);
                    }
                }
            }
        }

    }
}
