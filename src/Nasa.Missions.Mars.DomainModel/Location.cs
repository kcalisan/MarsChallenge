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
            ThrowIfInvalidLocation();

            cardinalDirectionsMapper = new Dictionary<CardinalDirection, char>
                {
                    {CardinalDirection.North, 'N'},
                    {CardinalDirection.East, 'E'},
                    {CardinalDirection.South, 'S'},
                    {CardinalDirection.West, 'W'}
                };
        }

        private void ThrowIfInvalidLocation()
        {
            if (Point.XCoordinate < 0 || Point.YCoordinate < 0)
                throw new ArgumentOutOfRangeException();
        }


        public Point Point { get; set; }
        public CardinalDirection CardinalDirection { get; set; }
        private readonly Dictionary<CardinalDirection, char> cardinalDirectionsMapper;

        public override string ToString()
        {
            return string.Format("{0} {1} {2}", Point.XCoordinate, Point.YCoordinate, cardinalDirectionsMapper[CardinalDirection]);
        }
    }
}
