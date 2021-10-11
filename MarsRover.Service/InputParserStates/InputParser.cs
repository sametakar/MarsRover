using System.Text.RegularExpressions;

namespace MarsRover.Service.InputParserStates
{
    public abstract class InputParser : IInputParser
    {
        public abstract void ExecuteInstruction(string input);
        public abstract Regex InputPattern { get; }
        public bool IsMatch(string input)
        {
            return InputPattern.IsMatch(input);
        }
    }
}