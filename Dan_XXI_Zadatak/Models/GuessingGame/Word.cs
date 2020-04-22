using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dan_XXI_Zadatak.Models.GuessingGame
{
    class Word : List<Leter>
    {
        public Word(string value)
        {
            foreach (var singleLetter in value)
            {
                this.Add(new Leter(singleLetter));
            }
        }

        /// <summary>
        /// Check if the list of letters contains a certain letter
        /// </summary>
        /// <param name="singleLetter"></param>
        /// <returns></returns>
        internal bool GuessLetter(char singleLetter)
        {
            var guessedLetters = this.Where(x => x.Value == singleLetter);

            if (guessedLetters.Count() == 0)
                return false;

            foreach (var letter in guessedLetters)
                letter.Guessed();

            return true;
        }


        /// <summary>
        /// Joining letters from list of letters to create string for screen representation
        /// </summary>
        /// <returns></returns>
        public string GetStringForScreen()
        {
            return string.Join(string.Empty, this.Select(x => x.GetSignIfNotGuessed()));
        }

        public override string ToString()
        {
            return string.Join(string.Empty, this.Select(x => x.ToString()));
        }

        public override bool Equals(object obj)
        {
            return Equals(obj, default);
        }

        public bool Equals(object obj, StringComparison comparison)
        {
            var stringRepresentatnion = obj as string;
            if (stringRepresentatnion == null)
                return false;

            var wordInStringRepresentation = this.ToString();

            if (stringRepresentatnion.Equals(wordInStringRepresentation, comparison))
            {
                return true;
            }

            return false;
        }

    }

}
