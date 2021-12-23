using RenameRules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Path = System.IO.Path;
namespace LowerCase
{
    public class LowerCase : IRenameRule
    {
        public string Name => "LowerCase";

        public string Process(string origin)
        {
            string fileName = Path.GetFileNameWithoutExtension(origin);
            string res = fileName.ToLower() + Path.GetExtension(origin);
            return res;
        }
       
        IRenameRule IRenameRule.Parse(string origin)
        {
            return new LowerCase();
        }
    }
}
