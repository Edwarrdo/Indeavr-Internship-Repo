using System;
using System.Collections.Generic;
using System.Text;

namespace Problem6.Models
{
    public class Matrix
    {
        private static Dictionary<Direction, Direction> directionSuccessorsTable = new Dictionary<Direction, Direction>()
        {
            { Direction.East, Direction.SouthEast },
            { Direction.SouthEast, Direction.South },
            { Direction.South, Direction.SouthWest },
            { Direction.SouthWest, Direction.West },
            { Direction.West, Direction.NorthWest },
            { Direction.NorthWest, Direction.North },
            { Direction.North, Direction.NorthEast },
            { Direction.NorthEast, Direction.East }
        };

        private int[,] matrix;

        private bool IsInRange(Point cellCoords)
        {
            return cellCoords.X >= 0 && cellCoords.X < matrix.GetLength(0) &&
                cellCoords.Y >= 0 && cellCoords.Y < matrix.GetLength(1);
        }

        private bool IsAvailable(Point cellCoords)
        {
            bool isInRange = IsInRange(cellCoords);
            return isInRange && this[cellCoords] == 0;
        }

        private Point FindFirstAvailableCell()
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 0)
                    {
                        return new Point(col, row);
                    }
                }
            }

            return Point.MatrixInvalidPoint;
        }

        public Matrix(int sideLength)
        {
            matrix = new int[sideLength, sideLength];
        }

        public int this[Point p]
        {
            get
            {
                return matrix[p.Y, p.X];
            }

            set
            {
                matrix[p.Y, p.X] = value;
            }
        }

        public Point GetSuccessorCellCoords(Point current, ref Direction lastDirection)
        {
            Direction nextValidDirectionCandidate = lastDirection;
            Point nextValidPointCandidate = current + nextValidDirectionCandidate;
            if (IsAvailable(nextValidPointCandidate))
            {
                return nextValidPointCandidate;
            }
            else
            {
                for (int i = 0; i < directionSuccessorsTable.Count; i++)
                {
                    nextValidDirectionCandidate = directionSuccessorsTable[nextValidDirectionCandidate];
                    nextValidPointCandidate = current + nextValidDirectionCandidate;
                    if (IsAvailable(nextValidPointCandidate))
                    {
                        lastDirection = nextValidDirectionCandidate;
                        return nextValidPointCandidate;
                    }
                }
                lastDirection = Direction.SouthEast;
                return FindFirstAvailableCell();
            }
        }

        public override string ToString()
        {
            StringBuilder outputBuffer = new StringBuilder();
            int fieldWidth = 1 + (int)Math.Log10(matrix.GetLength(0) * matrix.GetLength(1));
            string formatString = "{0," + fieldWidth + "}";
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    outputBuffer.AppendFormat(formatString, matrix[row, col]);
                    if (col != matrix.GetLength(1) - 1)
                    {
                        outputBuffer.Append(' ');
                    }
                }
                if (row != matrix.GetLength(0) - 1)
                {
                    outputBuffer.AppendLine();
                }
            }
            return outputBuffer.ToString();
        }
    }
}
