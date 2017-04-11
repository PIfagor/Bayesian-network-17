using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts
{
    public class Rule
    {
        public string Value         { get; private set; }
        public List<FactItem> Facts { get; private set; }

        public Rule(string val)
        {
            Value = val;
            Facts = new List<FactItem>();
        }

        public void AddFactItem(FactItem c)
        {
            Facts.Add(c);
        }

        public override string ToString()
        {
            var res = string.Empty;
            foreach (var factItem in Facts)
            {
                res += "\n" + factItem.ToString();
            }
            return "Fact result: " + Value + ", items: " + res;
        }
    }
}
