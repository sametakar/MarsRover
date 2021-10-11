using MarsRover.Model.Entities;
using MarsRover.Model.Enums;
using MarsRover.Service.Helpers;

namespace MarsRover.Service.InstructionStates
{
    public class SpinLeftInstruction : Instruction
    {
        public override InstructionType InstructionType => InstructionType.L;

        public override void Execute(Rover rover)
        {
            rover.Direction.ToDirectionState().SpinLeft(rover);
        }
    }

}
