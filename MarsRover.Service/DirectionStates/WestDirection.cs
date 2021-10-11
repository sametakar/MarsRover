using MarsRover.Model.Entities;
using MarsRover.Model.Enums;

namespace MarsRover.Service.DirectionStates
{
    public class WestDirection : Direction
    {
        public override DirectionType DirectionType => DirectionType.W;

        public override void MoveForward(Rover rover)
        {
            if (rover.X > 0)
                rover.X -= 1;
        }

        public override void SpinLeft(Rover rover)
        {
            rover.Direction = DirectionType.S;
        }

        public override void SpinRight(Rover rover)
        {
            rover.Direction = DirectionType.N;
        }
    }
}
