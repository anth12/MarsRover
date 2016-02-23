using MarsRover.Commands;
using MarsRover.Tests.Mock;
using Xunit;

namespace MarsRover.Tests
{
    public class RoverTurnTests
    {
        [Fact]
        public void Can_turn_rover()
        {
            var curiosity = MockRoverFactory.Curiosity();

            // Turn North
            curiosity.ExecuteCommands(
                    new TurnRoverCommand(Direction.North)
                );
            Assert.Equal(curiosity.Position.Direction, Direction.North);

            // Turn East
            curiosity.ExecuteCommands(
                    new TurnRoverCommand(Direction.East)
                );
            Assert.Equal(curiosity.Position.Direction, Direction.East);

            // Turn South
            curiosity.ExecuteCommands(
                    new TurnRoverCommand(Direction.South)
                );
            Assert.Equal(curiosity.Position.Direction, Direction.South);

            // Turn West
            curiosity.ExecuteCommands(
                    new TurnRoverCommand(Direction.West)
                );
            Assert.Equal(curiosity.Position.Direction, Direction.West);
        }
        
    }
}
