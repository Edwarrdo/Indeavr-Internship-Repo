using System;

namespace Problem27
{
    public class StartUp
    {
        public static void Main()
        {
            int fractionNumerator = int.Parse(Console.ReadLine());
            int fractionDenominator = int.Parse(Console.ReadLine());
            int gcd = GreatestCommonDivisor(fractionNumerator, fractionDenominator);
            fractionNumerator /= gcd;
            fractionDenominator /= gcd;
            Console.WriteLine(fractionNumerator + "/" + fractionDenominator);
        }
        private static int GreatestCommonDivisor(int firstNumber, int secondNumber)
        {
            if (firstNumber != 0)
            {
                int num1 = Math.Abs(firstNumber);
                int num2 = Math.Abs(secondNumber);
                if (num1 != num2)
                {
                    if (num1 > num2)
                    {
                        return GreatestCommonDivisor(num1 - num2, num2);
                    }
                    else
                    {
                        return GreatestCommonDivisor(num1, num2 - num1);
                    }

                }
                return num1;
            }
            else
            {
                return secondNumber;
            }
        }
    }


}
