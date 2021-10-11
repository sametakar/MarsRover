using MarsRover.Model.Entities;
using MarsRover.Model.Enums;
using MarsRover.Service.Helpers;

namespace MarsRover.Service.InstructionStates
{
    public class SpinRightInstruction : Instruction
    {
        public override InstructionType InstructionType => InstructionType.R;

        public override void Execute(Rover rover)
        {
            rover.Direction.ToDirectionState().SpinRight(rover);
        }
    }

}
