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
            var mainMenu = new Menu();
            mainMenu.DisplayMainMenu();
        }
    }
}