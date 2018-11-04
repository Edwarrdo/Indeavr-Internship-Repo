using System;

namespace Problem26
{
    public class StartUp
    {
        public static void Main(string[] args)
        {

            string firstInputLine = Console.ReadLine();
            string secondInputLine = Console.ReadLine();

            var firstFraction = Fraction.Parse(firstInputLine);

            var secondFraction = Fraction.Parse(secondInputLine);

            if ((firstFraction != null) && (secondFraction != null))
            {
                firstFraction.ToString();
                Console.WriteLine();
                secondFraction.ToString();
                Console.WriteLine();

                Fraction sumOfFractions = firstFraction + secondFraction;

                sumOfFractions.ToString();
                Console.Write(sumOfFractions.DecimalValue);

                Fraction subtractedFractions = firstFraction - secondFraction;
                Console.WriteLine();
                subtractedFractions.ToString();
                Console.WriteLine(subtractedFractions.DecimalValue);
            }
        }
    }
}
