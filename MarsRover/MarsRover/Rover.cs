using System;
using System.Collections.Generic;
using System.Linq;
using MarsRover.Commands;
using MarsRover.Exceptions;

namespace MarsRover
{
    /// <summary>
    /// Represents an operational remote Rover
    /// </summary>
    public class Rover
    {
        private const int MaximumCommands = 5;

        private const int DefaultCoordinateX = 0;
        private const int DefaultCoordinateY = 0;
        private const Direction DefaultDirection = Direction.South;

        #region Constructors

        public Rover()
        {
            Position = new RoverPosition(DefaultCoordinateX, DefaultCoordinateY, DefaultDirection);
            PastPositions = new List<RoverPosition>();
        }

        public Rover(int startCoordinateX, 
                    int startCoordinateY, 
                    Direction startDirection)
        {
            Position = new RoverPosition(startCoordinateX, startCoordinateY, startDirection);
            PastPositions = new List<RoverPosition>();
        }

        #endregion

        #region Properties

        public RoverPosition Position { get; private set; }
        public List<RoverPosition> PastPositions { get; }
        
        public Map Map { get; private set; }

        #endregion

        #region public Methods

        public void SetMap(Map map)
        {
            // Validate the start position is within the bounds of the map
            if (map.BoundaryX < Position.CoordinateX)
            {
                throw new OutOfBoundaryXException(map.BoundaryX, Position.CoordinateX);
            }
            if (map.BoundaryY < Position.CoordinateY)
            {
                throw new OutOfBoundaryYException(map.BoundaryY, Position.CoordinateY);
            }

            Map = map;
        }

        public void ExecuteCommands(params IRoverCommand[] commands)
        {
            ExecuteCommands(commands.ToList());
        }

        public void ExecuteCommands(IList<IRoverCommand> commands)
        {
            if (commands.Count > MaximumCommands)
            {
                throw new Exception($"Maximum commands exceeded. (Maximum: {MaximumCommands}, Actual: {commands.Count()})");
            }

            foreach (var command in commands)
            {
                var prospectivePosition = command.ExecuteOn(this.Position);

                // Note: Validation implementation may change to requirements, 
                // rather than throwing error the rover may halt at the boundary.

                // Validate the intended position
                if (prospectivePosition.CoordinateX < 0)
                {
                    throw new OutOfBoundaryXException(0, prospectivePosition.CoordinateX);
                }
                if (prospectivePosition.CoordinateY < 0)
                {
                    throw new OutOfBoundaryYException(0, prospectivePosition.CoordinateY);
                }

                if (prospectivePosition.CoordinateX > Map.BoundaryX)
                {
                    /*  Alternative implementation example
                    prospectivePosition.CoordinateX = Map.BoundaryX;
                    cancelOperations = true;
                    */

                    throw new OutOfBoundaryXException(Map.BoundaryX, prospectivePosition.CoordinateX);
                }
                if (prospectivePosition.CoordinateY > Map.BoundaryY)
                {
                    throw new OutOfBoundaryYException(Map.BoundaryY, prospectivePosition.CoordinateY);
                }

                // Set the new position
                PastPositions.Add(Position);
                Position = prospectivePosition;
            }
        }

        #endregion

    }
}
