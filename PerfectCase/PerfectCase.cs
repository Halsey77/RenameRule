using RenameRules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Path = System.IO.Path;
namespace PerfectCase
{
    //ki tu dau khong the la khoang trang va so, ki tu cuoi khong the la khong trang 
    // bo cac khoang trong >1 giua cac tu 
    // viet hoa sau " "neu la chu cai
    public class PerfectCase : IRenameRule
    {
        public string Name
        {
            get { return "PerfectCase"; }
        }
        /// <summary>
      
        /// </summary>
        /// <param name="origin"></param>
        /// <returns></returns>
        public string Process(string origin)
        {

            string res = "";
            string fileName = Path.GetFileNameWithoutExtension(origin);
            // loai bo khoang trong o dau dong va so 
            while (!Char.IsLetter(fileName, 0))
            {
                fileName = fileName.Remove(0, 1);
            }
            while (!Char.IsWhiteSpace(fileName[fileName.Length - 1]))
            {
                fileName = fileName.Remove(fileName.Length - 1, 1);
            }
            for (int i = 0; i < fileName.Length; i++)
            {
                if (i == 0)
                {
                    res = res + Char.ToUpper(fileName[i]);
                }
                else if (Char.IsWhiteSpace(fileName[i - 1]) && Char.IsLetter(fileName[i]))
                {
                    res = res + " " + Char.ToUpper(fileName[i]);
                }
                else if (Char.IsWhiteSpace(fileName[i - 1]) && !Char.IsWhiteSpace(fileName[i]))
                {
                    res = res + " " + fileName[i];
                }
                else if (!Char.IsWhiteSpace(fileName[i]))
                {
                    res = res + fileName[i];
                }
            }
            res = res + Path.GetExtension(origin);
            return res;

        }
       
        IRenameRule IRenameRule.Parse(string origin)
        {
            return new PerfectCase();
        }
    }

}
