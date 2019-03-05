using System;
using System.Collections.Generic;
using System.Text;

namespace Nasa.Missions.Mars.DomaninModel
{
    public class Rover
    {
        public Rover(Plateau plateau, Location location)
        {
            Plateau = plateau;
            Location = location;
        }

        public Plateau Plateau { get; private set; }
        public Location Location { get; private set; }
    }
}
