using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace Hangman
{
    class Word
    {
        private List<char> wordLetters = new List<char>();

        public Word()
        {
            this.wordLetters = PickWord();
        }

        public List<char> GetWordLetters()
        {
            return this.wordLetters;
        }

        // Loads list of words from csv and returns them in a list.
        public static List<string> LoadList()
        {
            List<string> wordList = new List<string>();
            string path = Path.Combine(Environment.CurrentDirectory, "Wordlist.csv");
            using (var reader = new StreamReader(@path))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(';');

                    wordList.Add(values[0]);
                }
            }
            return wordList;
        }

        // picks random word from loaded list
        public static List<char> PickWord() 
        {
            Random rnd = new Random();
            List<string> wordString = LoadList();
            List<char> wordLetters = new List<char>();
            wordLetters.AddRange(wordString[rnd.Next(wordString.Count())]);
            return wordLetters;
        }
    }
}
