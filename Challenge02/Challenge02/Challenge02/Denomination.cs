using Inflector;

namespace Challenge02
{
    public class Denomination
    {
        private readonly decimal _value;
        private readonly string _name;

        public int Count { get; private set; }
        public decimal Remainder { get; private set; }

        public decimal Amount => _value*Count;

        private string Name => Count != 1 ? _name.Pluralize() : _name;

        public Denomination(string name, decimal value)
        {
            _name = name;
            _value = value;
        }

        public void MakeChange(decimal change)
        {
            Count = (int)decimal.Truncate(change/_value);
            Remainder = change%_value;
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