using Dan_XXI_Zadatak.Interfaces;
using Dan_XXI_Zadatak.Models.GuessingGame;
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
                        var singleWords = new List<string>(10);
                        var shouldEscape = false;
                        do
                        {
                            var singleWord = HelpMethods.GetSingleWord("Enter a single word or enter stop to cancel:");
                            if (singleWord == Program.escapeSign)
                            {
                                shouldRepeat = true;
                                shouldEscape = true;
                                break;
                            }
                            if (singleWord.Equals("stop", StringComparison.InvariantCultureIgnoreCase))
                            {
                                //at least 2 words are necessary for this hangman game to make sense of choosing the random word for guessing
                                if (singleWords.Count < 2)
                                {
                                    Console.WriteLine("You must enter at least two words.");
                                    continue;
                                }

                                break;
                            }

                            singleWords.Add(singleWord);

                        } while (singleWords.Count < 10);

                        if (shouldEscape)
                            break;

                        var randomWordIndex = new Random().Next(0, singleWords.Count - 1);
                        //choosing the random word from user input words
                        var randomWord = new Word(singleWords[randomWordIndex]);
                        var numberOfLifes = 7;
                        do
                        {
                            Console.WriteLine("GUESS:");
                            Console.WriteLine($"Number of letters: {randomWord.Count}");
                            Console.WriteLine(randomWord.GetStringForScreen());

                            var numberChoise = HelpMethods.GetNumber("Do you want to guess:\n1) Whole word\n2) Letter by letter");
                            if (numberChoise == Program.escapeSign)
                            {
                                shouldRepeat = true;
                                numberOfLifes = 0;
                                continue;
                            }

                            var numberOfChoise = int.Parse(numberChoise);

                            switch (numberOfChoise)
                            {
                                case 1:
                                    //if option is to guess the whole word
                                    var resultSingleWord = HelpMethods.GetSingleWord("Enter a word:");
                                    if (resultSingleWord == Program.escapeSign)
                                    {
                                        numberOfLifes = 0;
                                        continue;
                                    }
                                    if (randomWord.Equals(resultSingleWord, StringComparison.InvariantCultureIgnoreCase))
                                    {
                                        Console.WriteLine("YOU WON THE GAME!");
                                        shouldRepeat = true;
                                        numberOfLifes = 0;
                                    }
                                    else
                                    {
                                        numberOfLifes--;
                                        Console.WriteLine($"Wrong. Remaining lifes: {numberOfLifes}");
                                    }
                                    break;
                                case 2:
                                    //if option is to guess the single letter
                                    Console.WriteLine("Enter a single letter:");
                                    var singleLetter = HelpMethods.GetSingleLetter("Enter a single letter:");
                                    if(singleLetter == Program.escapeSign)
                                    {
                                        numberOfLifes = 0;
                                        continue;
                                    }
                                  //  var singleLetter = Console.ReadKey(false).KeyChar;
                                    Console.WriteLine();
                                    if(!randomWord.GuessLetter(singleLetter.ToArray()[0]))
                                    {
                                        numberOfLifes--;
                                        Console.WriteLine($"Wrong. Remaining lifes: {numberOfLifes}");
                                    }
                                    break;
                                default:
                                    Console.WriteLine("Wrong input! Please try again.");
                                    break;
                            }

                        } while (numberOfLifes > 0);

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

        /// <summary>
        /// Replace the certain word in sectence with referenced word
        /// </summary>
        /// <param name="referencedSentence"></param>
        /// <param name="referencedWord"></param>
        /// <param name="wordToReplace"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Checks if a string i a palindrome
        /// </summary>
        /// <param name="input">a string to check</param>
        /// <returns></returns>
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
                residue = CalculateResidue(result, residue, value);
            }

            return string.Join("\n", result.Values.Select(x => x.ToString()));
        }

        /// <summary>
        /// Returns the residue after dividing amount of money with certain value 
        /// </summary>
        /// <param name="result">the collection that stores divided the amount of money</param>
        /// <param name="amount">amount of money to divide</param>
        /// <param name="value">value of bill or coin</param>
        /// <returns></returns>
        private int CalculateResidue(Dictionary<int, RSDMoney> result, int amount, int value)
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

        /// <summary>
        /// Returns initials of three word name 
        /// </summary>
        /// <param name="fullName">name as first, middle and last name</param>
        /// <returns></returns>
        public string GetFullNameInitials(string fullName)
        {
            var splitedName = fullName.Split(' ');
            var firstName = splitedName[0].ToUpper();
            var lastName = splitedName[2].ToUpper();
            return $"{firstName[0]}. {lastName[0]}.";
        }
    }
}
