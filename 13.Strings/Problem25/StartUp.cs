using System;
using System.Linq;

namespace Problem25
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string[] words = text.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(word => word.Trim()).ToArray();
            
            Array.Sort(words);
            Console.WriteLine(string.Join(Environment.NewLine, words));
        }

    }
}
