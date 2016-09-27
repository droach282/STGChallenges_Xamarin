using System;
using System.Collections.Generic;
using System.Linq;

namespace Challenge03
{
    public static class NumberParser
    {
        public static int Parse(string value)
        {
            var numbers = new List<decimal>();
            var letters = 0;

            foreach (var v in value)
            {
                if (char.IsLetter(v))
                    letters++;
                else if (char.IsNumber(v))
                    numbers.Add(decimal.Parse("" + v));
            }

            return (int) Math.Round(numbers.Sum()/letters, MidpointRounding.AwayFromZero);
        }
    }
}
