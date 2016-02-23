
namespace MarsRover.Commands
{
    public class TurnRoverCommand : IRoverCommand
    {
        public TurnRoverCommand(Direction direction)
        {
            Direction = direction;
        }

        /// <summary>
        /// Direction for a Rover to turn to
        /// </summary>
        public Direction Direction { get; set; }

        public RoverPosition ExecuteOn(RoverPosition position)
        {
            return new RoverPosition(position.CoordinateX, position.CoordinateY, Direction);
        }
    }
}
