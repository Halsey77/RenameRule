using RenameRules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Path = System.IO.Path;
namespace UniqueCase
{
    // tao mot ten ngau nhien
    public class UniqueCase : IRenameRule
    {
        public string Name
        {
            get { return "UniqueCase"; }
        }
        public string Process(string origin)
        {
            string fileName = Path.GetFileNameWithoutExtension(origin);
            var originalGuild = new Guid();
            string res = fileName + originalGuild.ToString();
            return res;
        }
    }
}
