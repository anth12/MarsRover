using System;

namespace MarsRover.Commands
{
    public class MoveRoverCommand : IRoverCommand
    {
        public MoveRoverCommand(int distance)
        {
            Distance = distance;
        }

        public int Distance { get; set; }

        public RoverPosition ExecuteOn(RoverPosition position)
        {
            switch (position.Direction)
            {
                case Direction.North:
                    return new RoverPosition(position.CoordinateX, position.CoordinateY - Distance, position.Direction);

                case Direction.East:
                    return new RoverPosition(position.CoordinateX + Distance, position.CoordinateY, position.Direction);

                case Direction.South:
                    return new RoverPosition(position.CoordinateX, position.CoordinateY + Distance, position.Direction);

                case Direction.West:
                    return new RoverPosition(position.CoordinateX - Distance, position.CoordinateY, position.Direction);
                default:
                    throw new NotImplementedException($"Direction {position.Direction} is not Implemented");
            }

        }
    }
}
