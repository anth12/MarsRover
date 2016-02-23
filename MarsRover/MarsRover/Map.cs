
namespace MarsRover
{
    public class Map
    {
        public Map(int boundaryX, int boundaryY)
        {
            BoundaryX = boundaryX;
            BoundaryY = boundaryY;
        }

        public int BoundaryX { get; set; }
        public int BoundaryY { get; set; }

        public bool IsValidPosition(RoverPosition position)
        {
            return position.CoordinateX <= BoundaryX
                && position.CoordinateY <= BoundaryY;
        }
    }
}
