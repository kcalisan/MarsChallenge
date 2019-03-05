using Nasa.Missions.Mars.DomaninModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nasa.Missions.Mars.DomainModel
{
    public static class RoverCardinalDirectionMapper
    {
        public static Dictionary<string, CardinalDirection> RoverCardinalDirectionMatcher = new Dictionary<string, CardinalDirection>
                {
                    {"N", CardinalDirection.North},
                    {"E", CardinalDirection.East},
                    {"S", CardinalDirection.South},
                    {"W", CardinalDirection.West}
                };
    }
}
