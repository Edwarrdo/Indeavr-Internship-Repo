using Problem7.Extentions;
using System;

namespace Problem7
{
    public class Program
    {
        static void Main(string[] args)
        {
            var text = Console.ReadLine();
            text = text.ToTitleCase();
            Console.WriteLine(text);
        }
    }
}
