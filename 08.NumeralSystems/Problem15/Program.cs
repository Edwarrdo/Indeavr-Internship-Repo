using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;

namespace Problem15
{
    class Program
    {
        const int MANTIS_LAST_INDEX = 22;
        const int EXPONENT_LAST_INDEX = 7;

        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            string inputLine = Console.ReadLine();
            float number = float.Parse(inputLine);

            int sign = GetFloatSign(number);
            Console.WriteLine($"{sign} ");

            long[] exponent = GetFloatExponent(number);
            foreach (var item in exponent)
            {
                Console.Write(item);
            }
            Console.WriteLine();

            long[] mantis = GetFloatMantis(number);
            foreach (var item in mantis)
            {
                Console.Write(item);
            }
            Console.WriteLine();
        }

        private static long[] GetFloatMantis(float number)
        {
            int mask = 0;
            for (int i = 0; i <= MANTIS_LAST_INDEX; i++)
            {
                int innerMask = (1 << i);
                mask = mask | innerMask;
            }

            int intRepresentation = BitConverter.ToInt32(BitConverter.GetBytes(number), 0);
            int mantis = intRepresentation & mask;

            List<long> binaryRepresentation = BinaryRepresentation(mantis);
            long[] mantisInBinary = new long[MANTIS_LAST_INDEX + 1];

            int mantisIndex = MANTIS_LAST_INDEX;
            for (int i = binaryRepresentation.Count - 1; i >= 0; i--)
            {
                mantisInBinary[mantisIndex] = binaryRepresentation[i];
                mantisIndex--;
            }

            return mantisInBinary;
        }

        private static long[] GetFloatExponent(float number)
        {
            int mask = 0;
            for (int i = MANTIS_LAST_INDEX + 1; i <= 30; i++)
            {
                int innerMask = (1 << i);
                mask = mask | innerMask;
            }

            int intRepresentation = BitConverter.ToInt32(BitConverter.GetBytes(number), 0);
            int exponent = intRepresentation & mask;
            exponent >>= MANTIS_LAST_INDEX + 1;

            List<long> binaryRepresentation = BinaryRepresentation(exponent);
            long[] exponentInBinary = new long[EXPONENT_LAST_INDEX + 1];

            int exponentIndex = EXPONENT_LAST_INDEX;
            for (int i = binaryRepresentation.Count - 1; i >= 0; i--)
            {
                exponentInBinary[exponentIndex] = binaryRepresentation[i];
                exponentIndex--;
            }

            return exponentInBinary;
        }

        private static int GetFloatSign(float number)
        {
            int intRepresentation = BitConverter.ToInt32(BitConverter.GetBytes(number), 0);
            int mask = (1 << 31);
            int intSign = intRepresentation & mask;

            if (intSign == 0)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }

        private static List<long> BinaryRepresentation(long number)
        {
            List<long> representation = new List<long>();
            long currentNumber = number;
            while (currentNumber != 0)
            {
                long currentRemainder = (currentNumber & 1);
                representation.Add(currentRemainder);
                currentNumber >>= 1;
            }

            while (representation.Count < 0)
            {
                representation.Add(0);
            }
            representation.Reverse();

            return representation;
        }

    }
}
