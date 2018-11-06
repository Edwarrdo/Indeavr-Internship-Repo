using System;
using System.Linq;

namespace Problem13
{
    public class StartUp
    {
        public static int GetValue(string polinom, int index, ref int value)
        {
            int result = 0;
            string number = string.Empty;
            while (int.TryParse(polinom[index].ToString(), out result))
            {
                number += polinom[index].ToString();
                index--;
            }
            if (number == string.Empty)
            {
                number += "1";
            }
            string reverseNumber = string.Empty;
            foreach (var digit in number.Reverse())
            {
                reverseNumber += digit;
            }
            result = int.Parse(reverseNumber);
            if (polinom[index] == '-')
            {
                result *= -1;
            }
            value = result;
            return index;//returns the index that we have to check next
        }

        static void GetDegree(string polinom, int index, ref int degree)
        {
            int result = 0;
            string stringDegree = string.Empty;
            if (polinom[index] == '^')
            {
                index++;
                while (int.TryParse(polinom[index].ToString(), out result))
                {
                    stringDegree += polinom[index].ToString();
                    index++;
                }
                if (stringDegree == string.Empty)
                {
                    stringDegree += "1";
                }
                result = int.Parse(stringDegree);
            }
            else
            {
                result = 1;
            }
            degree = result;
        }

        static int GetX(string polinom, int[] array, int i)
        {
            int index = 0;
            int value = 0;
            int degree = 0;
            index = GetValue(polinom, i - 1, ref value);
            GetDegree(polinom, i + 1, ref degree);
            array[degree] += value;

            return index;//returns the index that we have to check next
        }

        static void GetThePolinom(string polinom, int[] array)
        {
            for (int i = polinom.Length - 1; i >= 0; i--)
            {
                string currentSymbol = polinom[i].ToString();
                int result;
                if (currentSymbol == "X" || currentSymbol == "x")
                {
                    i = GetX(polinom, array, i);
                }
                if (int.TryParse(currentSymbol, out result))
                {
                    int testingIndex = i - 1;
                    while (int.TryParse(polinom[testingIndex].ToString(), out result))
                    {
                        testingIndex--;
                    }
                    if (polinom[testingIndex] == '+' || polinom[testingIndex] == '-')
                    {
                        int freeValue = 0;
                        i = GetValue(polinom, i, ref freeValue);
                        array[0] += freeValue;
                    }
                }
            }
        }

        static void PrintNewPolinom(int[] array)
        {
            string polinomal = string.Empty;
            for (int i = array.Length - 1; i > 0; i--)
            {
                if (array[i] != 0)
                {
                    if (polinomal.Length > 0)
                    {
                        if (array[i] > 0)
                            polinomal += "+";
                    }
                    if (array[i] != 1)
                    {
                        polinomal += array[i];
                    }
                    polinomal += "X";
                    if (i > 1)
                    {
                        polinomal += "^" + i;
                    }
                }
            }
            if (polinomal.Length > 0 && array[0] > 0)
            {
                polinomal += "+";
            }
            if (array[0] != 0)
            {
                polinomal += array[0];
            }
            Console.WriteLine(polinomal);
        }

        static void Multiplication(string polynomial1, string polynomial2)
        {
            int[] array = new int[1000];
            int[] array2 = new int[1000];
            int[] array3 = new int[2000];

            GetThePolinom(polynomial1, array);
            GetThePolinom(polynomial2, array2);

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length; j++)
                {
                    array3[i + j] += array[i] * array2[j];
                }
            }
            PrintNewPolinom(array3);
        }

        static void Main()
        {
            string polynomial1 = Console.ReadLine();
            polynomial1 = polynomial1.Replace(" ", "");
            string polinomal11 = "  " + polynomial1 + "  ";

            string polynomial2 = Console.ReadLine();
            polynomial2 = polynomial2.Replace(" ", "");
            string polinomal22 = "  " + polynomial2 + "  ";

            Multiplication(polinomal11, polinomal22);
        }

    }
}
