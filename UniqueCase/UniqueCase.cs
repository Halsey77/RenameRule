using RenameRules;
using System;
using Path = System.IO.Path;

namespace UniqueCase
{
    // tao mot ten ngau nhien
    public class UniqueCase : IRenameRule
    {
        public string Name => "UniqueCase";

        IRenameRule IRenameRule.Parse(string origin)
        {
            return new UniqueCase();
        }

        public string Process(string origin)
        {
            string fileName = Path.GetFileNameWithoutExtension(origin);
            var originalGuild = new Guid();
            string res = fileName + originalGuild;
            return res;
        }

        public IRenameRule Clone()
        {
            return new UniqueCase();
        }
    }
}
