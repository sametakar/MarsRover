using System.Text.RegularExpressions;

namespace MarsRover.Service.InputParserStates
{
    public interface IInputParser
    {
        void ExecuteInstruction(string input);
        Regex InputPattern { get; }
        bool IsMatch(string input);
    }
}