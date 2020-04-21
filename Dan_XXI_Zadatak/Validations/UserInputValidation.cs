using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dan_XXI_Zadatak.Validations
{
    class UserInputValidation
    {
        public int IsNumber(string userInput)
        {
            if (!int.TryParse(userInput, out int inputNumber) || char.IsWhiteSpace(userInput[0]))
                return 0;
            return inputNumber;
        }

        public bool ShouldReturn(string input, string returnSign)
        {
            if (input == returnSign)
                return true;
            return false;
        }
    }
}
