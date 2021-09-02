using System;
using System.IO;
using System.Text.RegularExpressions;


namespace Reader
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Enter the Path: ");
            string path = Console.ReadLine();
            bool exist = File.Exists(path);

            if (exist)
            {

                while (true)
                {
                    Console.Write("Enter a word: ");
                    string word = Console.ReadLine();
                    word = word.ToLower().Trim();
                    string readText = File.ReadAllText(path);
                    Console.Write("Enter a command: \n f-find word \n r- replace word \n d- delete word \n ");
                    string command = Console.ReadLine();
                    Regex regex = new Regex(word, RegexOptions.IgnoreCase);
                    switch (command)
                    {
                        case "f":
                            FindWord(readText, word, regex);
                            break;
                        case "r":
                            Console.Write("Enter replace: ");
                            string replace = Console.ReadLine();
                            ReplaceWord(readText, word, replace, path, regex);
                            break;
                        case "d":
                            DeleteWord(readText, word, path, regex);
                            break;
                        default:
                            Console.Write("UnKnown command  \n");

                            break;
                    }
                }
            }
            else
            {
                Console.Write("File is not exist \n");

            }
        }

        static void FindWord(string readText, string word, Regex regex)
        {

            int counter = 0;
           
            MatchCollection matches = regex.Matches(readText);
            if (matches.Count > 0)
            {
                foreach (Match match in matches) counter++;
                Console.Write($"the word occurs {counter} times  \n");
            }
            else
            {
                Console.Write("No matches found  \n");
            }
        }

        static void ReplaceWord(string readText, string word, string replace, string path, Regex regex)
        {
            readText = regex.Replace(readText, replace);
            
            using (StreamWriter file = new StreamWriter(path))
            {
                file.Write(readText);
            }
            Console.Write("Replaced successfully  \n");
        }
        static void DeleteWord(string readText, string word,string path, Regex regex)
        {
            readText = regex.Replace(readText, "");
            using (StreamWriter file = new StreamWriter(path))
            {
                file.Write(readText);
            }
            Console.Write("Deleted successfully \n");
        }
    }

}

