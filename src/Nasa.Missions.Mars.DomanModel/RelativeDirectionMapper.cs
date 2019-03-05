using Nasa.Missions.Mars.DomaninModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nasa.Missions.Mars.DomainModel
{
    public class RelativeDirectionMapper
    {
        public RelativeDirectionMapper(Rover rover)
        {
            Rover = rover;
            LeftCommandCardinalRotationMatcher = new Dictionary<CardinalDirection, Action>
                {
                    {CardinalDirection.North, () => Rover.Location.CardinalDirection = CardinalDirection.West},
                    {CardinalDirection.East, () => Rover.Location.CardinalDirection = CardinalDirection.North},
                    {CardinalDirection.South, () => Rover.Location.CardinalDirection = CardinalDirection.East},
                    {CardinalDirection.West, () => Rover.Location.CardinalDirection = CardinalDirection.South}
                };

            RightCommandCardinalRotationMatcher = new Dictionary<CardinalDirection, Action>
                {
                    {CardinalDirection.North, () => Rover.Location.CardinalDirection = CardinalDirection.East},
                    {CardinalDirection.East, () => Rover.Location.CardinalDirection = CardinalDirection.South},
                    {CardinalDirection.South, () => Rover.Location.CardinalDirection = CardinalDirection.West},
                    {CardinalDirection.West, () => Rover.Location.CardinalDirection = CardinalDirection.North}
                };

        }

        public readonly Dictionary<CardinalDirection, Action> LeftCommandCardinalRotationMatcher;
        public readonly Dictionary<CardinalDirection, Action> RightCommandCardinalRotationMatcher;
        public readonly Rover Rover;
    }
}






