using MarsRover.Model.Entities;
using MarsRover.Model.Enums;

namespace MarsRover.Service.DirectionStates
{
    public class NorthDirection : Direction
    {
        public override DirectionType DirectionType => DirectionType.N;

        public override void MoveForward(Rover rover)
        {
            if (rover.Y < rover.Plateau.Height)
                rover.Y += 1;
        }

        public override void SpinLeft(Rover rover)
        {
            rover.Direction = DirectionType.W;
        }

        public override void SpinRight(Rover rover)
        {
            rover.Direction = DirectionType.E;
        }
    }
}
