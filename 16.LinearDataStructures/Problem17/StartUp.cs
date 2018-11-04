using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Problem17
{
    public class StartUp
    {
        static StringBuilder result = new StringBuilder();
        static void ListDirectoryDFS(DirectoryInfo dir)
        {
            Stack<DirectoryInfo> stack = new Stack<DirectoryInfo>();

            stack.Push(dir);

            while (stack.Count > 0)
            {
                DirectoryInfo parentDir = stack.Pop();

                try
                {
                    DirectoryInfo[] listDir = parentDir.GetDirectories();

                    result.AppendLine(parentDir.ToString());

                    foreach (var currentDir in listDir)
                    {
                        ListDirectoryDFS(currentDir);
                    }
                }
                catch (UnauthorizedAccessException uae)
                {
                     Console.WriteLine(uae.Message);
                }
            }
        }

        static void Main(string[] args)
        {
            string path = Console.ReadLine();

            DirectoryInfo dir = new DirectoryInfo(path);

            ListDirectoryDFS(dir);
            Console.WriteLine(result.ToString().Trim());

        }
    }
}
