using System.Collections.Generic;
using System.Linq;

namespace Challenge02
{
    public class ChangeMaker
    {
        private readonly List<Denomination> _denominations = new List<Denomination>();

        public ChangeMaker()
        {
            var dictionary = new Dictionary<string, decimal>
            {
                {"$100 bill", 100},
                {"$50 bill", 50},
                {"$20 bill", 20},
                {"$10 bill", 10},
                {"$5 bill", 5},
                {"$1 bill", 1},
                {"quarter", 0.25m},
                {"dime", 0.10m},
                {"nickel", 0.05m},
                {"penny", 0.01m}
            };

            _denominations.AddRange(dictionary.Select(x => new Denomination(x.Key, x.Value)));
        }

        public void MakeChange(decimal change)
        {
            decimal remainder;
            var i = 0;

            do
            {
                var denomination = _denominations[i++];
                denomination.MakeChange(change);
                remainder = denomination.Remainder;
                change -= denomination.Amount;
            } while (remainder > 0m && i < _denominations.Count);
        }

        public void Reset()
        {
            foreach (var denomination in _denominations)
            {
                denomination.Reset();
            }
        }

        public override string ToString()
        {
            return string.Join(", ", _denominations.Where(x => x.Count > 0).Select(x => x.ToString()).ToArray());
        }
    }
}
