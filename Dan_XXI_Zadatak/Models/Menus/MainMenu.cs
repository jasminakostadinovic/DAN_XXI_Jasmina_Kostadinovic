using Dan_XXI_Zadatak.Interfaces;
using Dan_XXI_Zadatak.Models.Money;
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
            bool shouldRepeat;
            do
            {
                shouldRepeat = false;
                Console.WriteLine(message);
                Console.WriteLine(options.ToString());
                var inputNumber = UserInputValidation.IsNumber(Console.ReadLine());

                if (inputNumber == 0)
                {
                    Console.WriteLine("Wrong input! Please try again.");
                    shouldRepeat = true;
                    continue;
                }

                switch (inputNumber)
                {
                    case 1:

                        var stringInputPalindrome = HelpMethods.GetString("Enter the word or sentence you want to check if is a palindrome:");
                        if (stringInputPalindrome == Program.escapeSign)
                        {
                            shouldRepeat = true;
                            continue;
                        }
                        var isPalindrome = CheckIfAStringIsPalindrome(stringInputPalindrome);
                        if (isPalindrome)
                            Console.WriteLine($"\"{stringInputPalindrome}\" is a Palindrome!");
                        else
                            Console.WriteLine($"\"{stringInputPalindrome}\" is not a Palindrome!");

                        shouldRepeat = true;
                        continue;
                    case 2:
                        var inputAmout = HelpMethods.GetNumber("Enter the amount of mony you want to count:");
                        if (inputAmout == Program.escapeSign)
                        {
                            shouldRepeat = true;
                            continue;
                        }
                        Console.WriteLine(CountCoinsAndBills(int.Parse(inputAmout)));

                        shouldRepeat = true;
                        continue;
                    case 3:
                        var stringInputName = HelpMethods.GetFullName("Enter the first, middle and last name:");
                        if (stringInputName == Program.escapeSign)
                        {
                            shouldRepeat = true;
                            continue;
                        }
                        Console.WriteLine(GetFullNameInitials(stringInputName));
                    
                        shouldRepeat = true;
                        continue;
                    case 4:
                        var referencedWord = HelpMethods.GetSingleWord("Enter the referenced word:");
                        if (referencedWord == Program.escapeSign)
                        {
                            shouldRepeat = true;
                            continue;
                        }
                        var referencedSentence = HelpMethods.GetString("Enter the sentence with referenced word:");
                        if (referencedSentence == Program.escapeSign)
                        {
                            shouldRepeat = true;
                            continue;
                        }

                        Console.WriteLine(ReplaceReferencedWord(referencedSentence, "programming", referencedWord));

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

        private string ReplaceReferencedWord(string referencedSentence, string referencedWord, string wordToReplace)
        {
            var splitedSentence = referencedSentence.Split(' ');
            for( var i = 0; i < splitedSentence.Length; i++)
            {
                if (splitedSentence[i] == wordToReplace)
                    splitedSentence[i] = referencedWord;
            }
            return string.Join(" ", splitedSentence);
        }

        public bool CheckIfAStringIsPalindrome(string input)
        {
            var inputToLover = input.ToLower();
            var inputStriped = HelpMethods.StripPunctuation(inputToLover);
            var inputWithoutSpace = HelpMethods.RemoveWhitespace(inputStriped);
            var inputAsCharArr = inputWithoutSpace.ToCharArray();
            Array.Reverse(inputAsCharArr);
            var reversedInput = new string(inputAsCharArr);
            if (inputWithoutSpace.Equals(reversedInput))
                return true;
            return false;
        }

        public string CountCoinsAndBills(int amoutOfMoney)
        {
            var possibleValues = new int[] 
            {
                5000,
                2000,
                1000,
                500,
                200,
                100,
                50,
                20,
                10,
                5,
                2,
                1
            };

            var result = new Dictionary<int, RSDMoney>();
            var residue = amoutOfMoney;

            foreach(var value in possibleValues)
            {
                residue = CalculateValue(result, residue, value);
            }

            return string.Join("\n", result.Values.Select(x => x.ToString()));
        }

        private int CalculateValue(Dictionary<int, RSDMoney> result, int amount, int value)
        {
            int residue = amount;

            if (amount >= value)
            {
                var numberOfItems = amount / value;
                residue = amount % value;
                result.Add(value, new RSDMoney(numberOfItems, value));
            }

            return residue;
        }

        public string GetFullNameInitials(string fullName)
        {
            var splitedName = fullName.Split(' ');
            var firstName = splitedName[0].ToUpper();
            var lastName = splitedName[2].ToUpper();
            return $"{firstName[0]}. {lastName[0]}.";
        }
    }
}
