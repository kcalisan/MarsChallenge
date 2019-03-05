using System;
using System.Collections.Generic;
using System.Text;
using Nasa.Missions.Mars.DomainModel.Commands;
using Nasa.Missions.Mars.DomaninModel;

namespace Nasa.Missions.Mars.DomainModel.Builders
{
    public class RoverCommandListBuilder : IRoverCommandListBuilder
    {
        private readonly Dictionary<char, Func<Rover, RoboticRoverCommand>> roverCommandList;

        public RoverCommandListBuilder()
        {
            roverCommandList = new Dictionary<char, Func<Rover, RoboticRoverCommand>>
                {
                    {'L', rover => new TurnLeftCommand(rover)},
                    {'R', rover => new TurnRightCommand(rover)},
                    {'M', rover => new MoveForwardCommand(rover)}
                };
        }

        public ToBeExecutedRoverCommands Init(Rover rover, string commandArguments)
        {
            var toBeExecutedCommands = new ToBeExecutedRoverCommands();
            foreach (var command in commandArguments.ToUpper().ToCharArray())
            {
                try
                {
                    toBeExecutedCommands.Add(roverCommandList[command].Invoke(rover));
                }
                catch (Exception)
                {
                    throw new MarsDomainModelException(string.Format($"Invalid command arguments.{commandArguments}"));
                }
            }

            return toBeExecutedCommands;
        }
    }
}
