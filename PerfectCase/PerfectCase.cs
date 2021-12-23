using RenameRules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

        public string Process(string origin)
        {
            string res = "";
            string fileName = Path.GetFileNameWithoutExtension(origin);

            //loại bỏ tất cả khoảng trắng ở đầu và cuối
            res = fileName.Trim();

            //thay đổi những chỗ có 2+ khoảng trắng thành 1 khoảng trắng
            res = Regex.Replace(res, @"\s{2,}", " ");

            //Viết hoa những chữ cái đầu. Ex: "New line here" => "New Line Here"
            var regex = new Regex(@"\b[a-z]", RegexOptions.IgnoreCase);
            res = regex.Replace(res, m => m.ToString().ToUpper());

            res = res + Path.GetExtension(origin);
            return res;
        }

        IRenameRule IRenameRule.Parse(string origin)
        {
            return new PerfectCase();
        }
    }

}
