using System;
using UnityEngine;

namespace Assets.Scripts
{
    public static class Utils
    {

        public static Fact FactFromStr(string str)
        {
            var parts       = str.Split(':');

            if (parts.Length != 2)
            {
                Debug.LogErrorFormat("Wrong fact line format: [{0}]", str);
                return null;
            }

            var factName    = parts[0].Trim();
            Fact res        = new Fact(factName);
            var valParts    = parts[1].Split(',');

            foreach (var valPart in valParts)
            {
                res.AddValue(valPart.Trim());
            }

            return res;
        }

        public static Rule RuleFromStr(string str)
        {
            var parts = str.Split(new string[] {"->"}, StringSplitOptions.None);

            if (parts.Length != 2)
            {
                Debug.LogErrorFormat("Wrong factItem line format: [{0}]", str);
                return null;
            }

            var ruleRes = parts[1].Trim();
            Rule res = new Rule(ruleRes);

            var factParts = parts[0].Split('|');

            foreach (var factPart in factParts)
            {
                FactItem item = FactItemFromStr(factPart);
                if (item != null)
                {
                    res.AddFactItem(item);
                }
            }

            return res;
        }

        private static FactItem FactItemFromStr(string str)
        {
            var parts = str.Trim().Split('=');

            if (parts.Length != 2)
            {
                Debug.LogErrorFormat("Wrong factItem line format: [{0}]", str);
                return null;
            }

            return new FactItem(parts[0].Trim(), parts[1].Trim());
        }

    }
}
