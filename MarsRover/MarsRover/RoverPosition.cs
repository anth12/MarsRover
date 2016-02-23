
using System;
using System.Text.RegularExpressions;

namespace MarsRover
{
    /// <summary>
    /// Represents the position of a <see cref="Rover"/> on a <see cref="Map"/>
    /// </summary>
    public class RoverPosition
    {
        public RoverPosition(int coordinateX, int coordinateY, Direction direction)
        {
            CoordinateX = coordinateX;
            CoordinateY = coordinateY;
            Direction = direction;
        }

        /// <summary>
        /// Current direction the Rover is facing
        /// </summary>
        public Direction Direction { get; set; }

        /// <summary>
        /// Current X Coordinate of the Rover
        /// </summary>
        public int CoordinateX { get; set; }

        /// <summary>
        /// Current Y Coordinate of the Rover
        /// </summary>
        public int CoordinateY { get; set; }

        
        public override string ToString()
        {
            // Note the multiplier vale would be configurable to the map size
            return ((CoordinateX * 100) + CoordinateY) + " " + Direction;
        }

        public static RoverPosition Parse(string positionString)
        {
            if(Regex.IsMatch(positionString, @"\d{3,5}\s\w{4,5}") == false)
                throw new FormatException("The provided Position is not in a valid format");

            var positionSegments = positionString.Split(' ');

            var direction = (Direction) Enum.Parse(typeof (Direction), positionSegments[1]);

            int coordinateX;
            int coordinateY;
            if (positionSegments[0].Length <= 3)
            {
                coordinateX = int.Parse(positionSegments[0].Substring(0, 1));
                coordinateY = int.Parse(positionSegments[0].Substring(1, positionSegments[0].Length -1));
            }
            else
            {
                coordinateX = int.Parse(positionSegments[0].Substring(0, 2));
                coordinateY = int.Parse(positionSegments[0].Substring(2, positionSegments[0].Length -2));
            }
            return new RoverPosition(coordinateX, coordinateY, direction);
        }
    }
}
