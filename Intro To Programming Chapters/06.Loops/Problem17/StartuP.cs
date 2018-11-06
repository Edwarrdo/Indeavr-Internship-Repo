using System;

namespace Problem17
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());

            //im taking the product ot the numbers now because secondNum will change in the loop
            int absProduct = Math.Abs(firstNum * secondNum);

            int temp;
            while (firstNum != 0)
            {
                temp = firstNum;
                firstNum = secondNum % firstNum;
                secondNum = temp;
            }
            //now secondNum is the biggest devisor

            int biggestCommonMultiple = absProduct / secondNum;
            Console.WriteLine($"Biggest common devisor: {secondNum}");
            Console.WriteLine($"Least common multiple: {biggestCommonMultiple}");

        }
    }
}
