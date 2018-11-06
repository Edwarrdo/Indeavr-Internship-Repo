using System;

namespace Problem10
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int digit = int.Parse(Console.ReadLine());
            try
            {
                switch (digit)
                {
                    case 0:
                        throw new Exception("Bad Input!!!");
                    case 1:
                    case 2:
                    case 3:
                        digit = digit * 10;
                        Console.WriteLine(digit);
                        break;
                    case 4:
                    case 5:
                    case 6:
                        digit = digit * 100;
                        Console.WriteLine(digit);
                        break;
                    case 7:
                    case 8:
                    case 9:
                        digit = digit * 1000;
                        Console.WriteLine(digit);
                        break;
                    default:
                        throw new Exception("Bad Input!!!");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
