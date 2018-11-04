using System;

namespace Problem13
{
    public class Zad13
    {
        public static void Main(string[] args)
        {
            int firstNum = 5;
            int secondNum = 10;
            firstNum = firstNum + secondNum;
            secondNum = firstNum - secondNum;
            firstNum = firstNum - secondNum;
            Console.WriteLine($"a = {firstNum}");
            Console.WriteLine($"b = {secondNum}");
        }
    }

}
