using Xunit;

namespace MarsRover.Tests
{
    public class MapCoordinateTests
    {
        [Theory]
        [InlineData(1, 1,     Direction.North, "101 North" )]
        [InlineData(5, 1,     Direction.East,  "501 East"  )]
        [InlineData(1, 5,     Direction.South, "105 South" )]
        [InlineData(1, 16,    Direction.South, "116 South" )]
        [InlineData(12, 1,    Direction.East,  "1201 East" )]
        [InlineData(12, 14,   Direction.West,  "1214 West" )]
        [InlineData(46, 24,   Direction.North, "4624 North")]
        [InlineData(1, 99,    Direction.North, "199 North")]
        [InlineData(99, 1,    Direction.North, "9901 North")]
        [InlineData(100, 1,   Direction.West,  "10001 West")]
        [InlineData(100, 100, Direction.West,  "10100 West")]
        public void Can_report_map_coordinate(int coordinateX, int coordinateY, Direction direction, string expectedString)
        {
            var position = new RoverPosition(coordinateX, coordinateY, direction);
            Assert.Equal(expectedString, position.ToString());
        }

        [Theory]
        [InlineData("101 North",  1, 1,     Direction.North)]
        [InlineData("501 East",   5, 1,     Direction.East )]
        [InlineData("105 South",  1, 5,     Direction.South)]
        [InlineData("1201 East",  12, 1,    Direction.East )]
        [InlineData("1214 West",  12, 14,   Direction.West )]
        [InlineData("4624 North", 46, 24,   Direction.North)]
        public void Can_parse_map_coordinate(string positionString, int coordinateX, int coordinateY, Direction direction)
        {
            var position = RoverPosition.Parse(positionString);

            Assert.Equal(coordinateX, position.CoordinateX);
            Assert.Equal(coordinateY, position.CoordinateY);
            Assert.Equal(direction,   position.Direction);
        }
    }
}
