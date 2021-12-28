using RenameRules;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndCounterCase
{
    public class EndCounterCase : IRenameRule
    {
        public int currentNumber { get; set; }
        public int StartValue { get; set; }
        public int Step { get; set; }
        public int NumberOfDigit { get; set; }

        public string Name => "EndCounterCase";
        public EndCounterCase(int startValue, int step, int numberOfDigit)
        {
            Step = step;
            StartValue = startValue;
            currentNumber = StartValue;
            NumberOfDigit = numberOfDigit;
        }
        public EndCounterCase()
        {
            StartValue = 1;
            currentNumber =StartValue;
            Step = 1;
            NumberOfDigit = 1;
        }
        public IRenameRule Clone()
        {
            return new EndCounterCase(StartValue, Step, NumberOfDigit);
        }


        public IRenameRule Parse(string origin)
        {
            string[] tokens = origin.Split(' ');
            return new EndCounterCase(Int32.Parse(tokens[0]), Int32.Parse(tokens[1]), Int32.Parse(tokens[2]));
        }


        public string Process(string origin)
        {
            string fileName = Path.GetFileNameWithoutExtension(origin);
            fileName = fileName + currentNumber.ToString($"D{NumberOfDigit}");
            string res = fileName + Path.GetExtension(origin);
            currentNumber++;
            return res;

        }
        public override string ToString()
        {
            return $"{Name} {StartValue} {Step} {NumberOfDigit}";
        }
    }
}
