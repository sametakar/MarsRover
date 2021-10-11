using MarsRover.Model.Entities;
using MarsRover.Model.Enums;

namespace MarsRover.Service.DirectionStates
{
    public class EastDirection : Direction
    {
        public override DirectionType DirectionType => DirectionType.E;

        public override void MoveForward(Rover rover)
        {
            if (rover.X < rover.Plateau.Width)
                rover.X += 1;
        }

        public override void SpinLeft(Rover rover)
        {
            rover.Direction = DirectionType.N;
        }

        public override void SpinRight(Rover rover)
        {
            rover.Direction = DirectionType.S;
        }
    }
}
