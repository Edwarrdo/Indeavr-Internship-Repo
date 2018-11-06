using System;
using System.IO;

namespace Problem14
{
    public class StartUp
    {
        static void PrintSubfoldersAndFiles(string directoryPath, int depth)
        {
            string outstanding = new String(' ', depth);
            string directoryName = GetName(directoryPath);
            Console.WriteLine($"{outstanding}{directoryName}");

            string[] filesPaths = Directory.GetFiles(directoryPath);
            for (int i = 0; i < filesPaths.Length; i++)
            {
                string fileName = GetName(filesPaths[i]);
                Console.WriteLine($" {outstanding}{fileName}");
            }
            string[] directories = Directory.GetDirectories(directoryPath);
            for (int i = 0; i < directories.Length; i++)
            {
                string childDirectory = directories[i];
                PrintSubfoldersAndFiles(childDirectory, depth + 1);
            }
        }
        static string GetName(string path)
        {
            int startInd = path.LastIndexOf('\\') + 1;
            return path.Substring(startInd, path.Length - startInd);
        }
        static void Main()
        {
            string directoryPath = Console.ReadLine();
            PrintSubfoldersAndFiles(directoryPath, 0);
        }

    }
}
