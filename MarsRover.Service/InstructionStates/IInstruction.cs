using MarsRover.Model.Entities;
using MarsRover.Model.Enums;

namespace MarsRover.Service.InstructionStates
{
    public interface IInstruction
    {
        InstructionType InstructionType { get; }
        void Execute(Rover rover);
    }
}
