using System;

namespace Problem15
{
    class Program
    {
        static void Main(string[] args)
        {

            int number = int.Parse(Console.ReadLine());

            // Set starting positions
            int startPosition = 3;
            int countOfBits = 3;
            int exchangeFromPosition = 24;

            // getting the bits from the number
            int firstSeqBits = 0;
            int secondSeqBits = 0;
            for (int i = 0; i < countOfBits; i++)
            {
                if (0 != (number & (1 << (startPosition + i))))
                {
                    firstSeqBits |= (1 << i);
                }

                number &= ~(1 << startPosition + i);

                if (0 != (number & (1 << (exchangeFromPosition + i))))
                {
                    secondSeqBits |= (1 << i);
                }

                number &= ~(1 << exchangeFromPosition + i);
            }

            // exchanging the bits 
            number |= secondSeqBits << startPosition;
            number |= firstSeqBits << exchangeFromPosition;
            
            Console.WriteLine(number);
        }
    }

}
