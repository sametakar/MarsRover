using MarsRover.Model.Enums;

namespace MarsRover.Model.Entities
{
    public class Rover
    {
        public int X { get; set; }
        public int Y { get; set; }
        public DirectionType Direction { get; set; }
        public Plateau Plateau { get; set; }

        public Rover(int x, int y, DirectionType direction, Plateau plateau)
        {
            X = x;
            Y = y;
            Direction = direction;
            Plateau = plateau;
        }

        public override string ToString()
        {
            return $"{X} {Y} {Direction:G}";
        }
    }
}
