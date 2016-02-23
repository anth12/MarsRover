using System;
using MarsRover.Commands;
using MarsRover.Exceptions;
using MarsRover.Tests.Mock;
using Xunit;

namespace MarsRover.Tests
{
    public class RoverExceptionTests
    {
        [Fact]
        public void Can_validate_rover_map()
        {
            var spirit = new Rover(153, 12, Direction.East);
            var opportunity = new Rover(52, 101, Direction.North);

            var mars = new Map(100, 100);

            Assert.Throws<OutOfBoundaryXException>(() =>
            {
                spirit.SetMap(mars);
            });


            Assert.Throws<OutOfBoundaryYException>(() =>
            {
                opportunity.SetMap(mars);
            });
        }

        [Fact]
        public void Can_validate_command_count()
        {
            var curiosity = MockRoverFactory.Curiosity();

            Assert.Throws<Exception>(() =>
            {
                curiosity.ExecuteCommands(
                    RoverCommandBuilder.Create()
                    .Move(25)
                    .Turn(Direction.West)
                    .Move(30)
                    .Turn(Direction.South)
                    .Move(12)
                    .Turn(Direction.East)
                    .Move(3)
                    .Commands
                    );
            });
        }

        [Fact]
        public void Can_validate_command_bellow_bound()
        {
            // Validate X Start boundary
            Assert.Throws<OutOfBoundaryXException>(() =>
            {
                var curiosity = MockRoverFactory.Curiosity();

                curiosity.ExecuteCommands(
                    RoverCommandBuilder.Create()
                    .Move(25)
                    .Turn(Direction.West)
                    .Move(3)
                    .Commands
                    );
            });

            // Validate Y Start boundary
            Assert.Throws<OutOfBoundaryYException>(() =>
            {
                var curiosity = MockRoverFactory.Curiosity();

                curiosity.ExecuteCommands(
                    RoverCommandBuilder.Create()
                    .Turn(Direction.East)
                    .Move(25)
                    .Turn(Direction.North)
                    .Move(1)
                    .Commands
                    );
            });
        }

        [Fact]
        public void Can_validate_command_above_bound()
        {
            // Validate X Start boundary
            Assert.Throws<OutOfBoundaryXException>(() =>
            {
                var curiosity = MockRoverFactory.Curiosity();

                curiosity.ExecuteCommands(
                    RoverCommandBuilder.Create()
                    .Turn(Direction.East)
                    .Move(99)
                    .Turn(Direction.East)
                    .Move(2)
                    .Commands
                    );
            });

            // Validate Y Start boundary
            Assert.Throws<OutOfBoundaryYException>(() =>
            {
                var curiosity = MockRoverFactory.Curiosity();

                curiosity.ExecuteCommands(
                    RoverCommandBuilder.Create()
                    .Turn(Direction.South)
                    .Move(120)
                    .Commands
                    );
            });
        }

    }
}
