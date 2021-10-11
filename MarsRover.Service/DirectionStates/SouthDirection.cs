using MarsRover.Model.Entities;
using MarsRover.Model.Enums;

namespace MarsRover.Service.DirectionStates
{
    public class SouthDirection : Direction
    {
        public override DirectionType DirectionType => DirectionType.S;

        public override void MoveForward(Rover rover)
        {
            if (rover.Y > 0)
                rover.Y -= 1;
        }

        public override void SpinLeft(Rover rover)
        {
            rover.Direction = DirectionType.E;
        }

        public override void SpinRight(Rover rover)
        {
            rover.Direction = DirectionType.W;
        }
    }
}
