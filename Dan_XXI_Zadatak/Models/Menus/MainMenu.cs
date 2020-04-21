using Dan_XXI_Zadatak.Interfaces;
using Dan_XXI_Zadatak.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dan_XXI_Zadatak.Models.Menus
{
    class MainMenu : IMenu
    {
        public void CreateMenu(MenuOptions options, string message)
        {
            var validation = new UserInputValidation();
            bool shouldRepeat;
            do
            {
                shouldRepeat = false;
                Console.WriteLine(message);
                Console.WriteLine(options.ToString());
                var inputNumber = validation.IsNumber(Console.ReadLine());

                if (inputNumber == 0)
                {
                    Console.WriteLine("Wrong input! Please try again.");
                    shouldRepeat = true;
                    continue;
                }

                switch (inputNumber)
                {
                    case 1:


                        shouldRepeat = true;
                        continue;
                    case 2:
                        
                        shouldRepeat = true;
                        continue;
                    case 3:

                        shouldRepeat = true;
                        continue;
                    case 4:

                        shouldRepeat = true;
                        continue;
                    case 5:

                        shouldRepeat = true;
                        continue;
                    case 6:
                        shouldRepeat = false;
                        continue;
                    default:
                        Console.WriteLine("Wrong input! Please try again.");
                        shouldRepeat = true;
                        break;
                }
            } while (shouldRepeat);
        }
    }
}
