
namespace Assets.Scripts
{
    public class FactItem
    {
        public string Name  { get; private set; }
        public string Value { get; private set; }

        public FactItem(string name, string val)
        {
            Name    = name;
            Value   = val;
        }

        public override string ToString()
        {
            return string.Format("Name: {0}, value: {1}", Name, Value);
        }
    }
}
