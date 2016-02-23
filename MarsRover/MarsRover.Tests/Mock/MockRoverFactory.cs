
namespace MarsRover.Tests.Mock
{
    internal class MockRoverFactory
    {
        internal static Rover Curiosity(int startCoordinateX = 0, int startCoordinateY = 0)
        {
            var curiosity = new Rover(startCoordinateX, startCoordinateY, Direction.South);
            var mars = new Map(100, 100);

            curiosity.SetMap(mars);

            return curiosity;
        }
    }
}
