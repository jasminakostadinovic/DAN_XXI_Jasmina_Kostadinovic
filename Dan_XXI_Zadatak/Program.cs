using Dan_XXI_Zadatak.Models.Menus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dan_XXI_Zadatak
{
    class Program
    {
        public static string escapeSign = "#";
        public static string escapeMessage = $">>>To get back to the menu press '{escapeSign}' + ENTER<<<";
        static void Main(string[] args)
        {
            //creating main menu
            var mainMenu = new MainMenu();

            var optionsForMainMenu = new MenuOptions()
            {
                Options = new List<string>()
            {
                "Check if a string is a palindrome",
                "Count money (coins and bills)",
                "Get name initials",
                "Replace the reference word in the sentence with the word \"programming\"",
                "Guess the word you entered",
                "Exit"
            }
            };
            mainMenu.CreateMenu(optionsForMainMenu, "\nWelcome! Choose an option below:");
        }
    }
}
