using MarsRover.Model.Entities;

using MarsRover.Model.Enums;

namespace MarsRover.Service.DirectionStates
{
    public abstract class Direction : IDirection
    {
        public abstract DirectionType DirectionType { get; }
        public abstract void MoveForward(Rover rover);
        public abstract void SpinLeft(Rover rover);
        public abstract void SpinRight(Rover rover);
    }
}
