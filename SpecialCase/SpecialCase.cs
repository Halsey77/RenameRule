using RenameRules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Path = System.IO.Path;
namespace SpecialCase
{
    public class SpecialCase : IRenameRule
    {
        public string Name
        {
            get { return "SpecialCase"; }
        }
        public string Process(string origin)
        {
            string fileName = Path.GetFileNameWithoutExtension(origin).ToLower();
            string res = fileName.First().ToString().ToUpper() + fileName.Substring(1) + Path.GetExtension(origin);
            return res;
        }
    }
}
