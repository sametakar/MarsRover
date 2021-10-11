using MarsRover.Model.Entities;
using MarsRover.Model.Enums;
using MarsRover.Service.Plateaus;
using System;
using System.Collections.Generic;

namespace MarsRover.Service.RoverDeploys
{
    public class RoverDeployManager : IRoverDeployManager
    {
        public List<Rover> Rovers { get; } = new List<Rover>();
        public Rover LastDeployedRover { get; private set; }
        public IPlateauManager PlateauManager { get; }

        public RoverDeployManager(IPlateauManager plateauManager)
        {
            PlateauManager = plateauManager;
        }
        public void DeployRover(int x, int y, DirectionType direction)
        {
            IsValidPositionForDeploy(x, y);
            var rover = new Rover(x, y, direction, PlateauManager.Plateau);
            Rovers.Add(rover);
            LastDeployedRover = rover;
        }
        private void IsValidPositionForDeploy(int x, int y)
        {
            if (!(x >= 0 && x <= PlateauManager.Plateau.Width && y >= 0 && y <= PlateauManager.Plateau.Height))
                throw new Exception("Rover can not land to the plateau!");
        }
    }
}
