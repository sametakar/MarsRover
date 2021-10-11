using FluentAssertions;
using MarsRover.Service.Inputs;
using MarsRover.Service.Plateaus;
using MarsRover.Service.RoverDeploys;
using Microsoft.Extensions.DependencyInjection;
using System;
using Xunit;

namespace MarsRover.Test
{
    public class MarsRoverTest
    {
        [Theory]
        [InlineData("5 5\r\n1 2 N\r\nLMLMLMLMM\r\n3 3 E\r\nMMRMMRMRRM")]
        public void ExecuteValidInstruction(string inputs)
        {
            // Arrange
            ServiceProvider serviceProvider = new ServiceCollection()
                .AddSingleton<IRoverDeployManager, RoverDeployManager>()
                .AddSingleton<IPlateauManager, PlateauManager>()
                .AddSingleton<IInputManager, InputManager>()
                .BuildServiceProvider();

            InputManager inputManager = new InputManager(serviceProvider);

            IRoverDeployManager roverDeployManager = serviceProvider.GetService<IRoverDeployManager>();

            // Act
            inputManager.SendInstruction(inputs);

            // Assert
            roverDeployManager.Rovers.Should().NotBeNull();
            roverDeployManager.Rovers[0].ToString().Should().Be("1 3 N");
            roverDeployManager.Rovers[1].ToString().Should().Be("5 1 E");

            roverDeployManager.LastDeployedRover.Should().NotBeNull();
            roverDeployManager.LastDeployedRover.ToString().Should().Be("5 1 E");
            roverDeployManager.LastDeployedRover.ToString().Should().NotBe("4 2 W");
        }

        [Theory]
        [InlineData("5 A")]
        [InlineData("1 2 Z")]
        [InlineData("LMOMLMLMM")]
        public void InValidInput(string input)
        {
            // Arrange
            ServiceProvider serviceProvider = new ServiceCollection()
                .AddSingleton<IRoverDeployManager, RoverDeployManager>()
                .AddSingleton<IPlateauManager, PlateauManager>()
                .AddSingleton<IInputManager, InputManager>()
                .BuildServiceProvider();

            InputManager inputManager = new InputManager(serviceProvider);

            // Act
            Action act = () => inputManager.SendInstruction(input);


            // Assert
            act.Should()
                .Throw<Exception>()
                .WithMessage($"Wrong input: {input}");
        }

        [Theory]
        [InlineData("7 4 E")]
        public void OutOfBoundRoverDeployPosition(string roverDeployPosition)
        {
            // Arrange
            ServiceProvider serviceProvider = new ServiceCollection()
                .AddSingleton<IRoverDeployManager, RoverDeployManager>()
                .AddSingleton<IPlateauManager, PlateauManager>()
                .AddSingleton<IInputManager, InputManager>()
                .BuildServiceProvider();

            InputManager inputManager = new InputManager(serviceProvider);
            string plateau = "5 5";

            // Act
            inputManager.SendInstruction(plateau);

            Action act = () => inputManager.SendInstruction(roverDeployPosition);


            // Assert
            act.Should()
                .Throw<Exception>()
                .WithMessage("Rover can not land to the plateau!");
        }

        
    }
}
