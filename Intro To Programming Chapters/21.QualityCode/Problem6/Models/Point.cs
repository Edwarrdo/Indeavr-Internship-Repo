using System.Collections.Generic;

namespace Problem6.Models
{
    public class Point
    {
        private static Point matrixInvalidPoint;
        private static Dictionary<Direction, Point> offsetsTable = new Dictionary<Direction, Point>()
        {
            { Direction.North, new Point(0, -1) },
            { Direction.NorthEast, new Point(1, -1) },
            { Direction.East, new Point(1, 0) },
            { Direction.SouthEast, new Point(1, 1) },
            { Direction.South, new Point(0, 1) },
            { Direction.SouthWest, new Point(-1, 1) },
            { Direction.West, new Point(-1, 0) },
            { Direction.NorthWest, new Point(-1, -1) }
        };

        public int X { get; set; }
        public int Y { get; set; }

        public static Point MatrixInvalidPoint
        {
            get
            {
                if (matrixInvalidPoint == null)
                {
                    matrixInvalidPoint = new Point(-1, -1);
                }

                return matrixInvalidPoint;
            }
        }

        public Point() :
            this(0, 0)
        {
        }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public bool Equals(Point other)
        {
            return X == other.X && Y == other.Y;
        }

        public static Point operator +(Point p, Direction d)
        {
            Point offsetPoint = offsetsTable[d];
            return new Point(p.X + offsetPoint.X, p.Y + offsetPoint.Y);
        }

        public override string ToString()
        {
            return X + ":" + Y;
        }
    }
}
