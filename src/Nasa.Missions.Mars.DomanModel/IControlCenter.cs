using System;
using System.Collections.Generic;
using System.Text;

namespace Nasa.Missions.Mars.DomainModel
{
    public interface IControlCenter
    {
        void LoadsRoversOfCommands(string arguments);
        void Execute();
        string GetResult();
    }
}
