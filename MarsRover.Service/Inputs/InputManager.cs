using MarsRover.Service.Helpers;
using System;

namespace MarsRover.Service.Inputs
{
    public class InputManager : IInputManager
    {
        private readonly IServiceProvider _serviceProvider;

        public InputManager(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }


        public void SendInstruction(string inputs)
        {
            foreach (var input in inputs?.Trim()?.Split(Environment.NewLine, StringSplitOptions.None))
            {
                SendInstructionLine(input);
            }
        }

        public void SendInstructionLine(string input)
        {
            input.ToInputParserState(_serviceProvider).ExecuteInstruction(input);
        }
    }
}
