using System;
using System.Collections.Generic;
using System.Text;

namespace Hangman
{
    class Menu
    {
        private Dictionary<ConsoleKey, Action> menuDict = new Dictionary<ConsoleKey, Action>();

        public Menu()
        {
            this.menuDict = new Dictionary<ConsoleKey, Action>();
            this.menuDict.Add(ConsoleKey.D1, Game.CreateGame);
            this.menuDict.Add(ConsoleKey.D2, ExitGame);
        }

        public void DisplayMainMenu()
        {
            Console.WriteLine("Menu");
            Console.WriteLine("1. Start new Game");
            Console.WriteLine("2. Close Game");
            Console.WriteLine("");
            Console.WriteLine("Select an option!");
            CheckForKey();
        }

        public static void ExitGame()
        {
            Environment.Exit(0);
        }

        // Reads key and checks if its in dictionary. If not shows menu again.
        // Loops until valid input, then invokes dictionary method.
        public void CheckForKey()
        {
            ConsoleKeyInfo pressedKey = Console.ReadKey();

            foreach (var a in menuDict)
            {
                if (pressedKey.Key == a.Key)
                {
                    Console.Clear();
                    a.Value.Invoke();
                }
            }
            Console.Clear();
            DisplayMainMenu();
        }
    }
}
