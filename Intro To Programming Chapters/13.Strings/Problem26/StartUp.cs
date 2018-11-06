using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Problem26
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            const string TITLE_OPEN_TAG = "<title";
            const string TITLE_CLOSE_TAG = "</title>";

            var input = new StringBuilder();
            string line;
            do
            {
                line = Console.ReadLine();
                input.Append(line.Trim() + ' ');
            }
            while (line != "</html>");

            var output = new StringBuilder();

            // preparing the title
            int indexOfTitle = input.ToString().IndexOf(TITLE_OPEN_TAG);
            int startIndex = input.ToString().IndexOf('>', indexOfTitle) + 1;
            int length = input.ToString().IndexOf(TITLE_CLOSE_TAG) - startIndex;

            string title = input.ToString().Substring(startIndex, length);
            input = input.Remove(0, startIndex + length);
            output.AppendLine("Title: " + title);

            // preparing the body
            var tag = new Regex(@"<(?![!/]?[ABIU][>\s])[^>]*>");
            string body = tag.Replace(input.ToString(), "");
            output.AppendLine("Body:");
            output.Append(body.Trim());

            Console.WriteLine(output);
        }
    }
}
