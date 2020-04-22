using System;

namespace Dan_XXI_Zadatak.Models.GuessingGame
{
    public class Leter
    {
        protected bool IsGuessed;
        public char Value { get; protected set; }

        public Leter(char value)
        {
            Value = value;
        }

        public override string ToString()
        {
            return Value.ToString();
        }

        internal void Guessed()
        {
            IsGuessed = true;
        }

        internal string GetSignIfNotGuessed()
        {
            if (!IsGuessed)
                return "*";

            return Value.ToString();
        }
    }
}