
namespace MarsRover.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var curiosity = new Rover(0, 0, Direction.South);
            var mars = new Map(100, 100);

            curiosity.SetMap(mars);


        }
    }
}
