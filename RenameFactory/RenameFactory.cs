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
        static RenameFactory _instance = null;
        public IRenameRule Create(string choice)
        {
            if(choice=="")
            {
                return null;
            }
            if (choice.IndexOf(' ') == -1)
            {
                return _prototypes[choice].Parse(choice);
            }

            string firstWord = choice.Substring(0, choice.IndexOf(' ')).Trim();
            string choice1 = choice.Substring(choice.IndexOf(' ') + 1);
            return _prototypes[firstWord].Parse(choice1);
        }

        public static RenameFactory  getInstance()
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
                            var rule = Activator.CreateInstance(type) as IRenameRule;
                            if (rule != null)
                            {
                                _prototypes.Add(rule.Name, rule);
                            }
                        }
                    }
                }
            }

        }
    }
}
