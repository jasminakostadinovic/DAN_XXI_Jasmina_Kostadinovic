using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Dan_XXI_Zadatak.Validations
{
    class HelpMethods
    {
        public static string GetString(string message)
        {
            string consoleInput;
            bool shouldRepeat;
            do
            {
                shouldRepeat = false;
                Console.WriteLine(Program.escapeMessage);
                Console.WriteLine(message);

                consoleInput = Console.ReadLine();
                if (consoleInput == Program.escapeSign)
                    continue;
                if (String.IsNullOrWhiteSpace(consoleInput))
                {
                    Console.WriteLine("Wrong input! Please try again.");
                    shouldRepeat = true;
                    continue;
                }

                shouldRepeat = false;
            } while (shouldRepeat);
            return consoleInput;
        }

        public static string StripPunctuation(string s)
        {
            var sb = new StringBuilder();
            foreach (char c in s)
            {
                if (!char.IsPunctuation(c))
                    sb.Append(c);
            }
            return sb.ToString();
        }

        public static string RemoveWhitespace(string input)
        {
            return new string(input.ToCharArray()
                .Where(c => !Char.IsWhiteSpace(c))
                .ToArray());
        }

        public static string GetNumber(string message)
        {
            string consoleInput;
            bool shouldRepeat;
            do
            {
                shouldRepeat = false;
                Console.WriteLine(Program.escapeMessage);
                Console.WriteLine(message);

                consoleInput = Console.ReadLine();
                if (consoleInput == Program.escapeSign)
                    continue;
                if (UserInputValidation.IsNumber(consoleInput) <= 0)
                {
                    Console.WriteLine("Wrong input! Please try again.");
                    shouldRepeat = true;
                    continue;
                }

                shouldRepeat = false;
            } while (shouldRepeat);
            return consoleInput;
        }
        public static string GetFullName(string message)
        {
            string consoleInput;
            bool shouldRepeat;
            do
            {
                shouldRepeat = false;
                Console.WriteLine(Program.escapeMessage);
                Console.WriteLine(message);

                consoleInput = Console.ReadLine();
                if (consoleInput == Program.escapeSign)
                    continue;
                if (string.IsNullOrWhiteSpace(consoleInput) ||
                    !Regex.IsMatch(consoleInput, @"^[a-zA-Z ]+$") ||
                    !IsRequredNumberOfWords(consoleInput, 3))
                {
                    Console.WriteLine("Wrong input! Please try again.");
                    shouldRepeat = true;
                    continue;
                }

                shouldRepeat = false;
            } while (shouldRepeat);
            return consoleInput;
        }


        internal static string GetSingleWord(string message)
        {
            string consoleInput;
            bool shouldRepeat;
            do
            {
                shouldRepeat = false;
                Console.WriteLine(Program.escapeMessage);
                Console.WriteLine(message);

                consoleInput = Console.ReadLine();
                if (consoleInput == Program.escapeSign)
                    continue;
                if (string.IsNullOrWhiteSpace(consoleInput) ||
                    !Regex.IsMatch(consoleInput, @"^[a-zA-Z]+$"))
                {
                    Console.WriteLine("Wrong input! Please try again.");
                    shouldRepeat = true;
                    continue;
                }

                shouldRepeat = false;
            } while (shouldRepeat);
            return consoleInput;
        }

        public static bool IsRequredNumberOfWords(string s, int numberOfWords)
        {
            if (string.IsNullOrEmpty(s))
            {
                return false;
            }
            return s.Split(' ').Length == numberOfWords;
        }
    }
}
