using Nasa.Missions.Mars.DomaninModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nasa.Missions.Mars.DomainModel.Builders
{
    public interface IRoverCommandListBuilder
    {
        ToBeExecutedRoverCommands Init(Rover rover, string commandArguments);
    }
}
