using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Threading;

namespace Hangman
{
    class Game
    {
        private int lives { get; set; }
        private List<char> guessedLetters = new List<char>();   
        private Word gameWord = new Word();

        public Game()
        {
            this.lives = 8;
            this.guessedLetters = new List<char>();
            this.gameWord = new Word();
        }

        public static void CreateGame()
        {
            Game currentGame = new Game();
            currentGame.PlayGame();
        }

        // main game loop
        // game continues until won or 0 lives. Exits with a message (You lost or you won).
        public void PlayGame()
        {
            Console.WriteLine("Hello and welcome to a round of Hangman. Your word has been chosen");
            DrawLetters();
            while (lives != 0)
            {
                if (gameWord.GetWordLetters().Contains(TakeLetter()))
                {
                    if (DrawLetters() == gameWord.GetWordLetters().Count())
                    {
                        Console.WriteLine("You won!");
                        break;
                    }
                }
                else
                {
                    lives--;
                    if (lives != 1)
                    {
                        Console.WriteLine($"You guessed wrong :( \nYou have {lives} lives left!");
                    }
                    else
                    {
                        Console.WriteLine("You guessed wrong :( \nYou have 1 live left!");
                    }
                    DrawLetters();
                }
            }
            if (lives == 0)
            {
                Console.WriteLine("You lost! \nThe word was " + String.Join("", gameWord.GetWordLetters()));
            }
            Thread.Sleep(3000);
            Console.Clear();
            Menu mainMenu = new Menu();
            mainMenu.DisplayMainMenu();
        }

        // draws the word with correctly guessed letters (* for unguessed ones)
        public int DrawLetters()
        {
            var rightChars = 0;
            var letters = new List<char>();
            foreach (var i in gameWord.GetWordLetters())
            {

                if (guessedLetters.Contains(i))
                    {
                        letters.Add(i);
                        rightChars ++;
                    }
                else
                    {
                        letters.AddRange("*");
                    }
            }
            Console.WriteLine(String.Join("", letters));
            letters.Clear();
            return rightChars;
        }

        // Asks user for input and returns guessed letter if valid.
        public char TakeLetter()
        {
            Console.WriteLine("Guess a letter! ");
            var guess = Console.ReadLine().ToLower();
            if (CheckValidity(guess))
            {
                guessedLetters.AddRange(guess);
                return Convert.ToChar(guess);
            }
            else
            {
                return TakeLetter();
            }
        }

        // Checks guessed input for letter a-z that hasnt been guessed yet.
        public Boolean CheckValidity(string guess)
        {
            if (!Regex.IsMatch(guess, @"^[a-z]$"))
            {
                Console.WriteLine("Please enter a letter between A - Z");
                return false;
            }
            else
            {
                if (guessedLetters.Contains(guess[0]))
                {
                    Console.WriteLine($"You already guessed {guess[0]}");
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
    }
}
