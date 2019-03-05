using System;
using System.Collections.Generic;
using System.Text;

namespace Nasa.Missions.Mars.DomaninModel
{
    public class Plateau
    {
        public Plateau(Point point)
        {
            this.Grid = point;
        }

        public Point Grid { get; private set; }
    }
}
