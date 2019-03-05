using System;
using System.Collections.Generic;
using System.Text;

namespace Nasa.Missions.Mars.DomainModel
{
    public interface IRoverCommandParser
    {
        CommandsOfRowers Parse(string arguments);
    }
}
