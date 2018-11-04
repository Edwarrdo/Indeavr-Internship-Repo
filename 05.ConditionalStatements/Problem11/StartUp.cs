using System;

namespace Problem11
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int number = 0;

            Console.WriteLine("Please enter a number:");
            number = int.Parse(Console.ReadLine());
            if (number <= 999 && number >= 0)
            {
                int temp = number;
                switch (temp / 100)
                {
                    case 0:
                        break;
                    case 1:
                        Console.Write("Hundred ");
                        break;
                    case 2:
                        Console.Write("Two hundred ");
                        break;
                    case 3:
                        Console.Write("Three hundred ");
                        break;
                    case 4:
                        Console.Write("Four hundred ");
                        break;
                    case 5:
                        Console.Write("Five hundred ");
                        break;
                    case 6:
                        Console.Write("Six hundred ");
                        break;
                    case 7:
                        Console.Write("Seven hundred ");
                        break;
                    case 8:
                        Console.Write("Eight hundred ");
                        break;
                    case 9:
                        Console.Write("Nine hundred ");
                        break;

                    default: Console.WriteLine("Error report!"); break;
                }
                switch (temp / 10 % 10)
                {
                    case 0:
                        break;
                    case 1:
                        {
                            switch (temp % 10)
                            {
                                case 0:
                                    Console.WriteLine("ten ");
                                    break;
                                case 1:
                                    Console.WriteLine("eleven ");
                                    break;
                                case 2:
                                    Console.WriteLine("twelve ");
                                    break;
                                case 3:
                                    Console.WriteLine("thirteen ");
                                    break;
                                case 4:
                                    Console.WriteLine("fourteen ");
                                    break;
                                case 5:
                                    Console.WriteLine("fifteen ");
                                    break;
                                case 6:
                                    Console.WriteLine("sixteen ");
                                    break;
                                case 7:
                                    Console.WriteLine("seventeen ");
                                    break;
                                case 8:
                                    Console.WriteLine("eighteen ");
                                    break;
                                case 9:
                                    Console.WriteLine("nineteen ");
                                    break;

                                default: Console.WriteLine("Error report!"); break;
                            }
                        }
                        break;
                    case 2:
                        Console.Write("twenty ");
                        break;
                    case 3:
                        Console.Write("thirty ");
                        break;
                    case 4:
                        Console.Write("fourty ");
                        break;
                    case 5:
                        Console.Write("fifty ");
                        break;
                    case 6:
                        Console.Write("sixty ");
                        break;
                    case 7:
                        Console.Write("seventy ");
                        break;
                    case 8:
                        Console.Write("eighty ");
                        break;
                    case 9:
                        Console.Write("ninety ");
                        break;

                    default: Console.Write("Error report!"); break;
                }
                switch (temp % 10)
                {
                    case 0:
                        if (temp == 0)
                        {
                            Console.Write("zero");
                        }
                        Console.Write("\n ");
                        break;
                    case 1:
                        if (temp / 10 % 10 == 1) break;
                        Console.WriteLine("one");
                        break;
                    case 2:
                        if (temp / 10 % 10 == 1) break;
                        Console.WriteLine("two");
                        break;
                    case 3:
                        if (temp / 10 % 10 == 1) break;
                        Console.WriteLine("three");
                        break;
                    case 4:
                        if (temp / 10 % 10 == 1) break;
                        Console.WriteLine("four");
                        break;
                    case 5:
                        if (temp / 10 % 10 == 1) break;
                        Console.WriteLine("five");
                        break;
                    case 6:
                        if (temp / 10 % 10 == 1) break;
                        Console.WriteLine("six");
                        break;
                    case 7:
                        if (temp / 10 % 10 == 1) break;
                        Console.WriteLine("seven");
                        break;
                    case 8:
                        if (temp / 10 % 10 == 1) break;
                        Console.WriteLine("eight");
                        break;
                    case 9:
                        if (temp / 10 % 10 == 1) break;
                        Console.WriteLine("nine");
                        break;

                    default: Console.WriteLine("Error report!"); break;
                }
            }
            else
            {
                Console.WriteLine(" Out of range! ");
            }

        }
    }
}
