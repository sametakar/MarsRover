namespace MarsRover.Model.Entities
{
    public class Plateau
    {
        public int Width { get; }
        public int Height { get; }

        public Plateau(int width, int height)
        {
            Width = width;
            Height = height;
        }
    }
}
