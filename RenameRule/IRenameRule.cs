using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Path = System.IO.Path;
namespace RenameRules
{
    public interface IRenameRule
    {
        string Process(string origin);
        //void Parser(string origin1);

        string Name { get; }

        //void Parser(string line);

         IRenameRule Parse(string origin);

         IRenameRule Clone();

    }
   
}
