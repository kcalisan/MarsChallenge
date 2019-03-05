using Nasa.Missions.Mars.DomainModel.Builders;
using Nasa.Missions.Mars.DomaninModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nasa.Missions.Mars.DomainModel
{
    public class RoverCommandParser : IRoverCommandParser
    {
        public RoverCommandParser(IPlateauBuilder plateauBuilder, IRoverBuilder roverBuilder,IRoverCommandListBuilder roverCommandListBuilder )
        {
            this.plateauBuilder = plateauBuilder;
            this.roverBuilder = roverBuilder;
            this.roverCommandListBuilder = roverCommandListBuilder;
        }

        public CommandsOfRowers Parse(string arguments)
        {
            var commands = arguments.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            var commandsOfRowers = new CommandsOfRowers();

            this.plateau = this.plateauBuilder.Init(commands[0]);

            for (var line = 1; line < commands.Length; line = line + 2)
            {
                var rover = this.roverBuilder.Init(commands[line], this.plateau);
                var roverCommandList = this.roverCommandListBuilder.Init(rover, commands[line + 1]);

                if (rover != null)
                {
                    commandsOfRowers.Add(rover, roverCommandList);
                }
            }

            return commandsOfRowers;
        }

        private readonly IPlateauBuilder plateauBuilder;
        private readonly IRoverBuilder roverBuilder;
        private readonly IRoverCommandListBuilder roverCommandListBuilder;
        private Plateau plateau;
    }
}
