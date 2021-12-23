using RenameRules;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Replacer
{
    public class Replacer : IRenameRule
    {
        public string _needle { get; set; }
        public string _hammer { get; set; }
        public string Name => "Replacer";

        public Replacer(string needle, string hammer)
        {
            _needle = needle;
            _hammer = hammer;
        }

        //Chỉ thay đổi các needle trong tên file. Các needle trong phần mở rộng của file không thay đổi.
        public string Process(string origin)
        {
            string res = Path.GetFileNameWithoutExtension(origin);
            if (!String.IsNullOrEmpty(_needle))
            {
                res = res.Replace(_needle, _hammer);
            }
            res = res + Path.GetExtension(origin);
            return res;
        }

        IRenameRule IRenameRule.Parse(string origin)
        {
            string firstString = origin.Substring(0, origin.IndexOf(' '));
            string secondString=origin.Substring(origin.IndexOf(' ') + 1);
            
            return new Replacer(firstString, secondString);
        }
    }

  
}