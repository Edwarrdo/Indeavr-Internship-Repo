using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Problem13
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string inputText = string.Empty;
            List<string> words = new List<string>();
            using (StreamReader reader = new StreamReader("..//..//..//wordsToRead.txt"))
            {
                inputText = reader.ReadToEnd();
            }
            Match wordMatch = Regex.Match(inputText, @"(?<word>\w+)", RegexOptions.IgnoreCase);
            while (wordMatch.Success)
            {
                words.Add(wordMatch.Groups["word"].Value);
                wordMatch = wordMatch.NextMatch();
            }
            using (StreamReader reader = new StreamReader("..//..//..//textToRead.txt"))
            {
                inputText = reader.ReadToEnd();
            }
            Dictionary<string, int> dic = new Dictionary<string, int>();

            foreach (string word in words)
            {
                int counter = 0;
                wordMatch = Regex.Match(inputText, word, RegexOptions.IgnoreCase);
                while (wordMatch.Success)
                {
                    counter++;
                    wordMatch = wordMatch.NextMatch();
                }
                dic.Add(word, counter);
            }
            dic.OrderBy(x => x.Value);
            string outputText = "";
            foreach (var item in dic)
            {
                outputText += "The item " + item.Key + " is found " + item.Value + " times" + "\r\n";
            }
            try
            {
                using (StreamWriter writer = new StreamWriter("..//..//..//result.txt"))
                {
                    writer.Write(outputText);
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
