using RenameRules;
using System;
using System.IO;

namespace EndCounterCase
{
    public class EndCounterCase : IRenameRule
    {
        public int CurrentNumber { get; set; }
        public int StartValue { get; set; }
        public int Step { get; set; }
        public int NumberOfDigit { get; set; }

        public string Name => "EndCounterCase";
        public EndCounterCase(int startValue, int step, int numberOfDigit)
        {
            Step = step;
            StartValue = startValue;
            CurrentNumber = StartValue;
            NumberOfDigit = numberOfDigit;
        }
        public EndCounterCase()
        {
            StartValue = 1;
            CurrentNumber =StartValue;
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
            fileName = fileName + CurrentNumber.ToString($"D{NumberOfDigit}");
            string res = fileName + Path.GetExtension(origin);
            CurrentNumber += Step;
            return res;
        }

        public override string ToString()
        {
            return $"{Name} {StartValue} {Step} {NumberOfDigit}";
        }
    }
}
