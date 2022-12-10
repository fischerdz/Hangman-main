using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Hangman
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu mainMenu = new Menu();
            mainMenu.DisplayMainMenu();
        }
    }
}