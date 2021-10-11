using MarsRover.Model.Entities;

namespace MarsRover.Service.Plateaus
{
    public interface IPlateauManager
    {
        Plateau Plateau { get; }
        void SetSize(int width, int height);
    }
}
