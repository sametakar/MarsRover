namespace MarsRover.Service.Inputs
{
    public interface IInputManager
    {
        void SendInstruction(string inputs);
        void SendInstructionLine(string input);
    }

}
