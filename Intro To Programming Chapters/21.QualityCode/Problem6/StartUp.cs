using Problem6.Models;
using System;
using System.Diagnostics;
using System.IO;

namespace Problem6
{
    public enum Direction : byte
    {
        North,
        NorthEast,
        East,
        SouthEast,
        South,
        SouthWest,
        West,
        NorthWest
    }

    public class StartUp
    {
        public static void Main(string[] args)
        {
            ExecuteAndWriteToFile();
        }

        private static int ExecuteAndWriteToFile()
        {
            int width = GetMatrixSize();
            Stopwatch timer = new Stopwatch();
            timer.Start();
            Matrix programMainMatrix = new Matrix(width);
            Direction lastValidDirection = Direction.SouthEast;
            Point currentPosition = new Point(0, 0);
            int visitationsCount = 1;
            do
            {
                programMainMatrix[currentPosition] = visitationsCount;
                currentPosition = programMainMatrix.GetSuccessorCellCoords(currentPosition, ref lastValidDirection);
                visitationsCount++;
            } while (!currentPosition.Equals(Point.MatrixInvalidPoint));

            using (StreamWriter answerFile = new StreamWriter("answer" + width + ".txt"))
            {
                answerFile.Write(programMainMatrix);
            }
            Console.WriteLine(timer.Elapsed.TotalMilliseconds);
            return width;
        }

        private static int GetMatrixSize()
        {
            Console.WriteLine("Enter a number greater than zero");
            string input = Console.ReadLine();
            int width;
            while (!int.TryParse(input, out width) || width <= 0 || width > 100)
            {
                Console.WriteLine("You haven't entered a correct positive number");
                input = Console.ReadLine();
            }
            return width;
        }
    }
}
