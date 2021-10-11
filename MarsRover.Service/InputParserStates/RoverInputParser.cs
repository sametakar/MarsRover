using MarsRover.Model.Enums;
using MarsRover.Service.Helpers;
using MarsRover.Service.RoverDeploys;
using System;
using System.Text.RegularExpressions;
using Microsoft.Extensions.DependencyInjection;

namespace MarsRover.Service.InputParserStates
{
    public class RoverInputParser : InputParser
    {
        private readonly IRoverDeployManager _roverDeployManager;

        public RoverInputParser(IServiceProvider serviceProvider)
        {
            _roverDeployManager = serviceProvider.GetService<IRoverDeployManager>();
        }

        public override Regex InputPattern => new Regex($"^[{ string.Join("",Enum.GetNames(typeof(InstructionType))) }]+$");

        public override void ExecuteInstruction(string input)
        {
            var rover = _roverDeployManager.LastDeployedRover;

            if (rover != null)
            {
                foreach (var instruction in input?.ToEnumList<InstructionType>())
                {
                    instruction.ToInstructionState().Execute(rover);
                }

                Console.WriteLine(rover.ToString());
            }
        }
    }
}