using RenameRules;
using System.IO;
using System.Text.RegularExpressions;

namespace ExtensionCase
{
    public class ExtensionCase : IRenameRule
    {
        public string _Extension { get; set; }

        public ExtensionCase()
        {
            _Extension = "";
        }
        public ExtensionCase(string origin)
        {
            _Extension = origin;
        }
        public string getExtension()
        {
            return _Extension;
        }

        public string Name => "ExtensionCase";

        public IRenameRule Clone()
        {
            return new ExtensionCase(_Extension);
        }

        public override string ToString()
        {
            return Name + _Extension;
        }

        public string Process(string origin)
        {
            string fileName = Path.GetFileNameWithoutExtension(origin);

            string res = fileName + "." + _Extension;
            return res;
        }

        IRenameRule IRenameRule.Parse(string origin)
        {
            return new ExtensionCase(origin);
        }
    }
}
