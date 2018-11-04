using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Problem12
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string text = string.Empty;
            List<string> words = new List<string>();
            using (StreamReader reader = new StreamReader("..//..//..//wordsToRead.txt"))
            {
                text = reader.ReadToEnd();
            }
            Match wordMatch = Regex.Match(text, @"(?<word>\w+)", RegexOptions.IgnoreCase);
            while (wordMatch.Success)
            {
                words.Add(wordMatch.Groups["word"].Value);
                wordMatch = wordMatch.NextMatch();
            }
            using (StreamReader reader = new StreamReader("..//..//..//wordsToRead.txt"))
            {
                text = reader.ReadToEnd();
            }
            for (int i = 0; i < words.Count; i++)
            {
                text = text.Replace(words[i], "");
            }
            try
            {
                using (StreamWriter writer = new StreamWriter("..//..//..//wordsToDeleteFrom.txt"))
                {
                    writer.Write(text);
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File was not found");
            }
            catch (IOException)
            {
                Console.WriteLine("Cannot write");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
