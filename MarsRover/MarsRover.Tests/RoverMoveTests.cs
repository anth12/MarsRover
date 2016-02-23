using MarsRover.Commands;
using MarsRover.Tests.Mock;
using Xunit;

namespace MarsRover.Tests
{
    public class RoverMoveTests
    {
        [Fact]
        public void Can_move_rover()
        {
            var curiosity = MockRoverFactory.Curiosity(50, 50);

            // Turn move North
            curiosity.ExecuteCommands(
                    new TurnRoverCommand(Direction.North),
                    new MoveRoverCommand(5)
                );
            Assert.Equal(curiosity.Position.CoordinateY, 45);

            // Turn move East
            curiosity.ExecuteCommands(
                    new TurnRoverCommand(Direction.East),
                    new MoveRoverCommand(14)
                );
            Assert.Equal(curiosity.Position.CoordinateX, 64);

            // Turn move South
            curiosity.ExecuteCommands(
                    new TurnRoverCommand(Direction.South),
                    new MoveRoverCommand(9)
                );
            Assert.Equal(curiosity.Position.CoordinateY, 54);
            
            // Turn move West
            curiosity.ExecuteCommands(
                    new TurnRoverCommand(Direction.West),
                    new MoveRoverCommand(21)
                );
            Assert.Equal(curiosity.Position.CoordinateX, 43);
        }
        
    }
}
