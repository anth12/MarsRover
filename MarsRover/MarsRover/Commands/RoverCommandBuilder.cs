using System.Collections.Generic;

namespace MarsRover.Commands
{
    public class RoverCommandBuilder
    {
        #region Constructor

        public RoverCommandBuilder()
        {
            Commands = new List<IRoverCommand>();
        }

        #endregion

        #region Properties

        public List<IRoverCommand> Commands { get; set; }

        #endregion

        #region Methods

        public RoverCommandBuilder Move(int distance)
        {
            Commands.Add(new MoveRoverCommand(distance));
            return this;
        }

        public RoverCommandBuilder Turn(Direction direction)
        {
            Commands.Add(new TurnRoverCommand(direction));
            return this;
        }

        #endregion

        #region Static Methods

        public static RoverCommandBuilder Create()
        {
            return new RoverCommandBuilder();
        }
        
        #endregion
    }
}
