using MarsRover.Model.Entities;
using MarsRover.Model.Enums;
using MarsRover.Service.Helpers;

namespace MarsRover.Service.InstructionStates
{
    public class MoveForwardInstruction : Instruction
    {
        public override InstructionType InstructionType => InstructionType.M;

        public override void Execute(Rover rover)
        {
            rover.Direction.ToDirectionState().MoveForward(rover);
        }
    }

}
