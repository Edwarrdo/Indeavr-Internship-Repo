using System;

namespace Problem13
{
    public class StartUp
    {
        static int[,] matrix;
        static int n;
        static int largestArea;
        static void Main(string[] args)
        {
            n = int.Parse(Console.ReadLine());
            matrix = new int[n, n];
            InputMatrix();
            FindLargestAdjacent();
        }

        private static void FindLargestAdjacent()
        {
            largestArea = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (matrix[i, j] == 1)
                    {
                        continue;
                    }
                    int currentArea = LargestAdgescent(i, j, 1);
                    if (largestArea < currentArea)
                    {
                        largestArea = currentArea;
                    }
                }
            }
            Console.WriteLine(largestArea);
        }

        static bool IsValidPosition(int x, int y)
        {
            if (x < 0 || y < 0 || x >= n || y >= n)
            {
                return false;
            }
            if (matrix[x, y] == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        static int[,] directions = { { 0, 1 }, { 0, -1 }, { 1, 0 }, { -1, 0 } };

        static int LargestAdgescent(int x, int y, int area)
        {
            if (!IsValidPosition(x, y))
            {
                return 0;
            }

            matrix[x, y] = 1;

            for (int i = 0; i < 4; i++)
            {
                int newX = x + directions[i, 0];
                int newY = y + directions[i, 1];
                area += LargestAdgescent(newX, newY, 1);
            }

            return area;
        }


        private static void InputMatrix()
        {
            for (int i = 0; i < n; i++)
            {
                string line = Console.ReadLine();
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = line[j] - '0';
                }
            }

        }
    }
}
