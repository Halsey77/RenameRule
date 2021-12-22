using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RenameRules;
using System.IO;
using System.Reflection;
using System.Diagnostics;

namespace RenameFactory
{
    public class RenameFactory
    {
        Dictionary<string, IRenameRule> _prototypes;
        RenameFactory _instance = null;

        IRenameRule Create(string choice)
        {
            string firstWord = choice.Substring(0, choice.IndexOf(' '));
            string choice1 = choice.Substring(choice.IndexOf(' ') + 1);
            return _prototypes[firstWord].Parse(choice1);
            // LAY CHU DAU , NEU CHU DAU =
            // STRING CHOICE1
            // _pROTOTYPES[[choice - 1].pARSE(CHOICE- CHOICE1);
        }
        RenameFactory getInstance()
        {
            if (_instance == null)
                _instance = new RenameFactory();
            return _instance;
        }
        RenameFactory()
        {
            _prototypes = new Dictionary<string, IRenameRule>();
            var exeFolder = AppDomain.CurrentDomain.BaseDirectory;
            var dlls = new DirectoryInfo(exeFolder).GetFiles("*.dll");

            foreach (var dll in dlls)
            {
                var assembly = Assembly.LoadFile(dll.FullName);
                var types = assembly.GetTypes();

                foreach (var type in types)
                {
                    Debug.WriteLine(type);
                    if (type.IsClass)
                    {
                        if (typeof(IRenameRule).IsAssignableFrom(type))
                        {
                            var shape = Activator.CreateInstance(type) as IRenameRule;
                            if (shape != null)
                            {
                                _prototypes.Add(shape.Name, shape);
                            }
                        }
                    }
                }
            }

        }
    }
}
