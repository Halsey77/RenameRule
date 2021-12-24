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
        string Name { get; }

        string Process(string origin);
        IRenameRule Parse(string origin);
        IRenameRule Clone();
    }
   
}
