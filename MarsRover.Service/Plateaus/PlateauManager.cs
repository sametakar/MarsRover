using MarsRover.Model.Entities;

namespace MarsRover.Service.Plateaus
{
    public class PlateauManager : IPlateauManager
    {
        public Plateau Plateau { get; private set; }

        public void SetSize(int width, int height)
        {
            Plateau = new Plateau(width, height);
        }
    }
}
