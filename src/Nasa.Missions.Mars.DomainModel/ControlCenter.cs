using System;
using System.Collections.Generic;
using System.Text;

namespace Nasa.Missions.Mars.DomainModel
{
    public class ControlCenter : IControlCenter
    {

        public ControlCenter(IRoverCommandParser roverCommandParser, ICommandInvoker commandInvoker)
        {
            this.roverCommandParser = roverCommandParser;
            this.commandInvoker = commandInvoker;
            MarsRoverMissionState = MarsRoverMissionState.Initial;
        }

        private readonly IRoverCommandParser roverCommandParser;
        private readonly ICommandInvoker commandInvoker;
        private CommandsOfRowers commandsOfRowers;

        public MarsRoverMissionState MarsRoverMissionState { get; private set; }

        public void Execute()
        {
            if (this.MarsRoverMissionState != MarsRoverMissionState.CommandsInitialized)
                throw new MarsDomainModelException("Commands cannot be executed before they are initialized.");

            commandInvoker.Execute(commandsOfRowers);

            this.MarsRoverMissionState = MarsRoverMissionState.Completed;
        }

        public string GetResult()
        {
            var result = new StringBuilder();

            foreach (var rover in commandsOfRowers)
            {
                result.AppendLine(rover.Key.Location.ToString());
            }

            return result.ToString();
        }

        public void LoadsRoversOfCommands(string arguments)
        {
            commandsOfRowers = roverCommandParser.Parse(arguments);
            this.MarsRoverMissionState = MarsRoverMissionState.CommandsInitialized;
        }
    }
}
