using System;
using System.Collections.Generic;
using System.Text;

namespace Nasa.Missions.Mars.DomainModel
{
    public class CommandInvoker : ICommandInvoker
    {
        public void Execute(CommandsOfRowers commandsOfRowers)
        {
            foreach (var rover in commandsOfRowers)
            {
                foreach (var command in rover.Value)
                {
                    command.Execute();
                }
            }
        }
    }
}
