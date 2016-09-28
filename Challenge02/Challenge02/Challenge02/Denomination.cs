using Inflector;

namespace Challenge02
{
    public class Denomination
    {
        private readonly decimal _value;
        private readonly string _name;

        private decimal _remainder;

        public Denomination NextDenomination { get; set; }

        public int Count { get; private set; }

        private string Name => Count != 1 ? _name.Pluralize() : _name;

        public Denomination(string name, decimal value)
        {
            _name = name;
            _value = value;
        }

        public void MakeChange(decimal change)
        {
            Count = (int)decimal.Truncate(change/_value);
            _remainder = change%_value;
            if (_remainder > 0)
                NextDenomination?.MakeChange(_remainder);
        }

        public override string ToString()
        {
            return $"{Count} {Name}";
        }

        public void Reset()
        {
            Count = 0;
        }
    }
}