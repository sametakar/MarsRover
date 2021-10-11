using MarsRover.Model.Enums;
using MarsRover.Service.Helpers;
using MarsRover.Service.RoverDeploys;
using System.Text.RegularExpressions;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace MarsRover.Service.InputParserStates
{
    public class RoverDeployInputParser : InputParser
    {
        private readonly IRoverDeployManager _roverDeployManager;

        public RoverDeployInputParser(IServiceProvider serviceProvider)
        {
            _roverDeployManager = serviceProvider.GetService<IRoverDeployManager>();
        }

        public override Regex InputPattern => new Regex($"^\\d+ \\d+ [{ string.Join("", Enum.GetNames(typeof(DirectionType))) }]$");

        public override void ExecuteInstruction(string input)
        {
            ParseInput(input, out var x, out var y, out var direction);
            _roverDeployManager.DeployRover(x, y, direction);
        }

        private static void ParseInput(string input, out int x, out int y, out DirectionType direction)
        {
            var roverInfo = input.Split(' ');
            x = int.Parse(roverInfo[0]);
            y = int.Parse(roverInfo[1]);
            direction = roverInfo[2].ToEnum<DirectionType>();
        }
    }
}