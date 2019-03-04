using System;
using System.Collections.Generic;
using System.Text;

namespace Nasa.Missions.Mars.DomaninModel
{
    public class Location
    {
        public Location(Point point, CardinalDirection cardinalDirection)
        {
            this.Point = point;
            this.CardinalDirection = cardinalDirection;

            cardinalDirections = new Dictionary<CardinalDirection, char>
                {
                    {CardinalDirection.North, 'N'},
                    {CardinalDirection.East, 'E'},
                    {CardinalDirection.South, 'S'},
                    {CardinalDirection.West, 'W'}
                };
        }

        public Point Point { get; set; }
        public CardinalDirection CardinalDirection { get; set; }
        private readonly Dictionary<CardinalDirection, char> cardinalDirections;
    }
}
