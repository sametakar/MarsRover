using MarsRover.Model.Entities;
using MarsRover.Model.Enums;

namespace MarsRover.Service.DirectionStates
{
    public interface IDirection
    {
        DirectionType DirectionType { get; }
        void MoveForward(Rover rover);
        void SpinLeft(Rover rover);
        void SpinRight(Rover rover);
    }
}
