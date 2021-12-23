using RenameRules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Path = System.IO.Path;
namespace UpperCase
{
    // viet in hoa
    public class UpperCase : IRenameRule
    {
        public string Name => "UpperCase";

        public string Process(string origin)
        {
            string fileName = Path.GetFileNameWithoutExtension(origin);
            string res = fileName.ToUpper() + Path.GetExtension(origin);
            return res;
        }
   

        IRenameRule IRenameRule.Parse(string origin)
        {
            return new UpperCase();
        }
    }
 
   
    
   
}
