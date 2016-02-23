
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
            return $"X: {CoordinateX}; Y: {CoordinateY}; Direction: {Direction}";
        }
    }
}
