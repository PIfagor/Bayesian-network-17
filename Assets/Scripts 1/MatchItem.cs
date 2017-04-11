
namespace Assets.Scripts
{
    public class MatchItem
    {
        public int  ParamMatchCount { get; private set; }
        public Rule Rule            { get; private set; }

        public MatchItem(int count, Rule r)
        {
            ParamMatchCount = count;
            Rule            = r;
        }

        public override string ToString()
        {
            return "Matched params: " + ParamMatchCount + ", result: " + Rule.Value;
        }
    }
}
