
namespace MarsRover.Commands
{
    public interface IRoverCommand
    {
        RoverPosition ExecuteOn(RoverPosition position);
    }
}
