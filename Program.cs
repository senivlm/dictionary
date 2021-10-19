using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace dictionary
{
    class MyDictionary
    {
        private Dictionary<string, string> my_dictionary;

        public MyDictionary(Dictionary<string, string> my_dictionary)
        {
            this.my_dictionary = new Dictionary<string, string>();
            this.my_dictionary = my_dictionary;
        }

        public static Dictionary<string, string> ReadDictionary(string filepath)
        {
            Dictionary<string, string> dctnr = new Dictionary<string, string>();
            string[] readLines = File.ReadAllLines(filepath);
            foreach(string line in readLines)
            {
                string[] subs = line.Split("-");
                dctnr.Add(subs[0], subs[1]);
            }
            return dctnr;
        }

        public string Translate(string inputText)
        {
            
            string[] spliters = {" ",", ",". ",": ", "; ",") ","( ", " - " };
            string[] subs = inputText.Split(spliters, StringSplitOptions.None);
            foreach(string word in subs)
            {
                if (this.my_dictionary.ContainsKey(word))
                {
                    inputText =  inputText.Replace(word, this.my_dictionary[word]);
                }
                else
                {
                    Тут мав би бути цикл, поки користувач не введе слово
                    Console.WriteLine($"Your dictionary does not contain word {word}. Please, enter enter the meaning of this word: ");
                   inputText = inputText.Replace(word, Console.ReadLine());
                }

            }
            return inputText;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter path of your dictionary");
            var d = new MyDictionary(MyDictionary.ReadDictionary(Console.ReadLine()));
            Console.WriteLine("Enter yor text");
            
            Console.WriteLine(d.Translate(Console.ReadLine()));

        }
    }
}
