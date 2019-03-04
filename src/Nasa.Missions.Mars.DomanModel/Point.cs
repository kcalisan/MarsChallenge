using System;
using System.Collections.Generic;
using System.Text;

namespace Nasa.Missions.Mars.DomaninModel
{
    /// <summary>
    /// Represent Two-Dimensional coordinate system.
    /// </summary>
    public class Point
    {
        public Point(int xCoordinate, int yCoordinate)  
        {
            this.XCoordinate = xCoordinate;
            this.YCoordinate = yCoordinate;
        }

        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }
    }
}
