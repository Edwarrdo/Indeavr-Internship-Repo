using System;

namespace Problem18
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());
            int[,] matrix = new int[matrixSize, matrixSize];
            //we are going to fill the matrix with the value of num
            int num = 1;

            //im going to fill the matrix starting from the outer layer and going inwards,
            //int depth indicates at what depth we are in the matrix
            for (int depth = 0; depth < matrixSize / 2 + matrixSize % 2; depth++)
            {
                for (int col = depth; col < matrixSize - depth; col++)
                {
                    matrix[depth, col] = num;
                    num++;
                }

                for (int row = 1 + depth; row < matrixSize - depth; row++)
                {
                    matrix[row, matrixSize - 1 - depth] = num;
                    num++;
                }

                for (int col = matrixSize - 2 - depth; col >= depth; col--)
                {
                    matrix[matrixSize - 1 - depth, col] = num;
                    num++;
                }

                for (int row = matrixSize - 2 - depth; row > depth; row--)
                {
                    matrix[row, depth] = num;
                    num++;
                }
            }

            PrintMatrix(matrix);
        }

        private static void PrintMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write("{0,4}", matrix[row, col]);
                }
                Console.WriteLine();
            }
        }

    }
}
