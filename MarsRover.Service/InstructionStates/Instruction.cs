using MarsRover.Model.Entities;
using MarsRover.Model.Enums;

namespace MarsRover.Service.InstructionStates
{
    public abstract class Instruction : IInstruction
    {
        public abstract InstructionType InstructionType { get; }
        public abstract void Execute(Rover rover);
    }
}
