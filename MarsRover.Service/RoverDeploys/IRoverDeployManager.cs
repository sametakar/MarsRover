using MarsRover.Model.Entities;
using MarsRover.Model.Enums;
using MarsRover.Service.Plateaus;
using System.Collections.Generic;

namespace MarsRover.Service.RoverDeploys
{
    public interface IRoverDeployManager
    {
        List<Rover> Rovers { get; }
        Rover LastDeployedRover { get; }
        IPlateauManager PlateauManager { get; }
        void DeployRover(int x, int y, DirectionType direction);
    }
}
