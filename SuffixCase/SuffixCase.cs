using RenameRules;
using System.IO;
using System.Text.RegularExpressions;

namespace SuffixCase
{
    public class SuffixCase : IRenameRule
    {
        public string _suffix { get; set; }

        public SuffixCase()
        {
            _suffix = "";
        }
        public SuffixCase(string origin)
        {
            _suffix = origin;
        }
        public string getPrefix()
        {
            return _suffix;
        }

        public string Name => "SuffixCase";

        public IRenameRule Clone()
        {
            return new SuffixCase(_suffix);
        }

        public override string ToString()
        {
            return Name + _suffix;
        }

        public string Process(string origin)
        {
            string fileName = Path.GetFileNameWithoutExtension(origin);
            fileName = fileName + _suffix;
            string res = fileName + Path.GetExtension(origin);
            return res;
        }

        IRenameRule IRenameRule.Parse(string origin)
        {
            return new SuffixCase(origin);
        }
    }
}
