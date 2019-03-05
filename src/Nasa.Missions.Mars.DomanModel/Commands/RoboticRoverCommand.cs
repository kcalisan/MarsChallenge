using Nasa.Missions.Mars.DomaninModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nasa.Missions.Mars.DomainModel.Commands
{
    public abstract class RoboticRoverCommand
    {
        public RoboticRoverCommand(Rover rover)
        {
            Rover = rover;
        }

        public abstract void Execute();

        public readonly Rover Rover;
    }
}
