using RenameRules;
using System.Text.RegularExpressions;

namespace SpecialCase
{
    public class SpecialCase : IRenameRule
    {
        public string Name => "SpecialCase";

        public string Process(string origin)
        {
            return Regex.Replace(origin, @"^(\s*[^\s])", m => m.ToString().ToUpper());
        }

        IRenameRule IRenameRule.Parse(string origin)
        {
            return new SpecialCase();
        }
    }
}
