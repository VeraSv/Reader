using System;
using System.IO;
using System.Text.RegularExpressions;
namespace Reader
{
    class Program
    {
        static void Main(string[] args)
        {
            //System.IO.File file = new File();
            Console.Write("Enter the path to the file: ");
            string path = Console.ReadLine();
           
            bool exist = File.Exists(path);
            
            if (exist) {
                Console.Write("Enter a word: ");
                string word = Console.ReadLine();
                word = word.ToLower().Trim();
                string readText = File.ReadAllText(path);
                int counter = 0;
                Regex regex = new Regex(word, RegexOptions.IgnoreCase);
                MatchCollection matches = regex.Matches(readText);
                if (matches.Count > 0)
                {
                    foreach (Match match in matches) counter++;
                    Console.Write($"the word occurs {counter} times");
                }
                else
                {
                    Console.WriteLine("No matches found");
                }
              
            }
            else
            {
                Console.Write("File is not exist");
            }

        }
    }
}
