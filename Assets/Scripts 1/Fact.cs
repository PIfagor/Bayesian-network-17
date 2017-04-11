using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts
{
    public class Fact
    {
        public string Name          { get; private set; }
        public List<string> Values  { get; private set; }

        public Fact(string name)
        {
            Name    = name;
            Values  = new List<string>();
        }

        public void AddValue(string val)
        {
            Values.Add(val);
        }

        public override string ToString()
        {
            var vals = string.Empty;
            foreach (var value in Values)
            {
                vals += value + ", ";
            }

            return "Fact [" + Name + "], " + vals;
        }
    }
}
