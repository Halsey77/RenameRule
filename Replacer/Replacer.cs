using RenameRules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Replacer
{
    public class Replacer : IRenameRule
    {
        public string _needle { get; set; }
        public string _hammer { get; set; }
        public string Name
        {
            get { return "Replacer"; }
        }
        public string Process(string origin)
        {
            var needle = _needle;
            var hammer = _hammer;
            string res = "";
            // neu chuoi needle khong chua hoac khong ton tai thi khong phai thay the
            if (!origin.Contains(needle) || String.IsNullOrEmpty(needle))
            {
                res = origin;
            }
            else
            {
                res = origin.Replace(needle, hammer);
            }
            return res;
        }
    }

  
}
