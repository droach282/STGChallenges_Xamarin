using System;

namespace Challenge01
{
    public class Value : IComparable
    {
        private char letter;
        private int number;

        public Value(string input)
        {
            letter = input[0];
            var numString = ""; // no sense using a StringBuilder, it's only two characters.
            for (int i = 1; i < input.Length; i++)
            {
                numString += input[i];
            }

            number = int.Parse(numString);
        }

        public override string ToString()
        {
            return $"{letter}{number}";
        }

        public int CompareTo(object obj)
        {
            var other = obj as Value;
            if (other == null)
                return 0;

            if (letter == other.letter)
                return number - other.number;

            return letter - other.letter;
        }
    }
}