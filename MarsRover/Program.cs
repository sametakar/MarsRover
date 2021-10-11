using MarsRover.Service.Inputs;
using MarsRover.Service.Plateaus;
using MarsRover.Service.RoverDeploys;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace MarsRover
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceProvider serviceProvider = new ServiceCollection()
                .AddSingleton<IRoverDeployManager, RoverDeployManager>()
                .AddSingleton<IPlateauManager, PlateauManager>()
                .AddSingleton<IInputManager, InputManager>()
                .BuildServiceProvider();



            InputManager inputManager = new InputManager(serviceProvider);

            string inputs = "5 5\r\n" +
                            "1 2 N\r\n" +
                            "LMLMLMLMM\r\n" +
                            "3 3 E\r\n" +
                            "MMRMMRMRRM";


            inputManager.SendInstruction(inputs);   // if you want to send instructions line by line you can use SendInstructionLine method




            /*
            string inputs = @"5 5
1 2 N
LMLMLMLMM
3 3 E
MMRMMRMRRM";
            */


            /* BY LINE */

            //inputManager.SendInstructionLine("5 5");
            //inputManager.SendInstructionLine("1 2 N");
            //inputManager.SendInstructionLine("LMLMLMLMM");
            //inputManager.SendInstructionLine("3 3 E");
            //inputManager.SendInstructionLine("MMRMMRMRRM");


            /* V1 */

            //IRoverDeployManager _roverDeployManager = serviceProvider.GetService<IRoverDeployManager>();
            //IPlateauManager _plateauManager = serviceProvider.GetService<IPlateauManager>();
            //IInputManager _inputManager = serviceProvider.GetService<IInputManager>();

            //_plateauManager.SetSize(5, 5);

            //_roverDeployManager.DeployRover(1, 2, "N".ToEnum<DirectionType>());
            //inputManager.SendInstructionLine(_roverSquadManager.LastDeployedRover, "LMLMLMLMM");

            //_roverDeployManager.DeployRover(3, 3, "E".ToEnum<DirectionType>());
            //inputManager.SendInstructionLine(_roverSquadManager.LastDeployedRover, "MMRMMRMRRM");

            Console.ReadKey();
        }
    }
}
