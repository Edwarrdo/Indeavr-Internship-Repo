using System;
using System.Collections.Generic;
using System.Text;

namespace Problem18
{
    enum CellType { NORMAL = 0, NON_PASSABLE = -1, START = -2 };

    class Cell
    {
        private int row;
        private int col;

        public int Row
        {
            get { return this.row; }
            set { this.row = value; }
        }

        public int Col
        {
            get { return this.col; }
            set { this.col = value; }
        }

        public Cell() { }

        public Cell(int row, int col)
        {
            this.Row = row;
            this.Col = col;
        }
    }
    public class StartUp
    {
        static int[,] Read(out Cell startCell)
        {
            int n = int.Parse(Console.ReadLine());

            int[,] maze = new int[n, n];
            startCell = new Cell(0, 0);

            for (int i = 0; i < maze.GetLength(0); i++)
            {
                string line = Console.ReadLine();
                string[] splittedLine = line.Split(' ');

                for (int j = 0; j < maze.GetLength(1); j++)
                {
                    switch (splittedLine[j][0])
                    {
                        case 'x':
                            maze[i, j] = (int)CellType.NON_PASSABLE;
                            break;

                        case '*':
                            maze[i, j] = (int)CellType.START;
                            startCell.Row = i;
                            startCell.Col = j;
                            break;

                        default:
                            maze[i, j] = (int)CellType.NORMAL;
                            break;
                    }
                }
            }

            return maze;
        }

        static void Print(int[,] maze)
        {
            for (int i = 0; i < maze.GetLength(0); i++)
            {
                var line = new StringBuilder();

                for (int j = 0; j < maze.GetLength(1); j++)
                {
                    switch (maze[i, j])
                    {
                        case (int)CellType.NON_PASSABLE:
                            line.Append("x ");
                            break;

                        case (int)CellType.START:
                            line.Append("* ");
                            break;

                        case (int)CellType.NORMAL: // after walk is unpassable
                            line.Append("u ");
                            break;

                        default:
                            line.Append(maze[i, j] + " ");
                            break;
                    }
                }

                Console.WriteLine(line.ToString().Trim());
            }
        }

        static bool InMaze(Cell cell, int rows, int cols)
        {
            return (cell.Row >= 0 && cell.Row < rows && cell.Col >= 0 && cell.Col < cols);
        }

        static void Walk(int[,] maze, Cell startCell)
        {
            int[] rowOffset = new int[] { -1, 1, 0, 0 };
            int[] colOffset = new int[] { 0, 0, -1, 1 };

            int n = maze.GetLength(0);

            bool[,] visited = new bool[n, n];

            Queue<Cell> queue = new Queue<Cell>();

            queue.Enqueue(startCell);

            while (queue.Count > 0)
            {
                Cell currentCell = queue.Dequeue();

                for (int i = 0; i < rowOffset.Length; i++)
                {
                    Cell cell = new Cell(currentCell.Row + rowOffset[i], currentCell.Col + colOffset[i]);

                    if (!InMaze(cell, n, n))
                    {
                        continue;
                    }

                    bool isVisited = visited[cell.Row, cell.Col];
                    bool isPassable = (maze[cell.Row, cell.Col] >= (int)CellType.NORMAL);

                    if (!isVisited && isPassable)
                    {
                        queue.Enqueue(cell);
                        visited[cell.Row, cell.Col] = true;

                        if (maze[currentCell.Row, currentCell.Col] != (int)CellType.START)
                        {
                            maze[cell.Row, cell.Col] = maze[currentCell.Row, currentCell.Col] + 1;
                        }
                        else
                        {
                            maze[cell.Row, cell.Col] = 1;
                        }
                    }
                }
            }

        }

        static void Main(string[] args)
        {
            Cell startCell = new Cell();
            int[,] maze = Read(out startCell);

            Walk(maze, startCell);
            Print(maze);
        }

    }
}
