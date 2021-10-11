using MarsRover.Service.Plateaus;
using System;
using System.Text.RegularExpressions;
using Microsoft.Extensions.DependencyInjection;

namespace MarsRover.Service.InputParserStates
{
    public class PlateauInputParser : InputParser
    {
        private readonly IPlateauManager _plateauManager;

        public PlateauInputParser(IServiceProvider serviceProvider)
        {
            _plateauManager = serviceProvider.GetService<IPlateauManager>();
        }

        public override Regex InputPattern => new Regex("^\\d+ \\d+$");

        public override void ExecuteInstruction(string input)
        {
            ParseInput(input, out var width, out var height);
            _plateauManager.SetSize(width, height);
        }

        private static void ParseInput(string input, out int width, out int height)
        {
            var size = input.Split(' ');
            width = int.Parse(size[0]);
            height = int.Parse(size[1]);
        }
    }
}