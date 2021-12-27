using RenameRules;
using System.IO;
using System.Text.RegularExpressions;

namespace PrefixCase
{
    public class PrefixCase : IRenameRule
    {
        public string _prefix { get; set; }
        
        public PrefixCase()
        {
            _prefix = "";
        }
        public PrefixCase(string origin)
        {
            _prefix = origin;
        }
        public string getPrefix()
        {
            return _prefix;
        }

        public string Name => "PrefixCase";

        public IRenameRule Clone()
        {
            return new PrefixCase(_prefix);
        }

        public override string ToString()
        {
            return Name + _prefix;
        }

        public string Process(string origin)
        {
            string fileName = Path.GetFileNameWithoutExtension(origin);
            fileName=_prefix+ fileName; 
            string res=fileName+Path.GetExtension(origin);
            return res;
        }

        IRenameRule IRenameRule.Parse(string origin)
        {
         
            return new PrefixCase(origin);
           
        }
    }
}
