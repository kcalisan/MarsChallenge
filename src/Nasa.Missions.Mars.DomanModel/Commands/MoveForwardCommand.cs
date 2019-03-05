using Nasa.Missions.Mars.DomaninModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nasa.Missions.Mars.DomainModel.Commands
{
    public class MoveForwardCommand : RoboticRoverCommand
    {

        public MoveForwardCommand(Rover rover) : base(rover)
        {
            cardinalDirectionRoutes = new Dictionary<CardinalDirection, Action>
                {
                    {CardinalDirection.North, () => CheckPositionAndSetLocation(0, 1)},
                    {CardinalDirection.East, () => CheckPositionAndSetLocation(1, 0)},
                    {CardinalDirection.South, () => CheckPositionAndSetLocation(0, -1)},
                    {CardinalDirection.West, () => CheckPositionAndSetLocation(-1, 0)}
                };
        }

        private void CheckPositionAndSetLocation(int x, int y)
        {
            var targetLocation = new Point(Rover.Location.Point.XCoordinate + x, Rover.Location.Point.YCoordinate + y);

            if (ThrowIfLocationIsOutsideOfThePlateau(targetLocation))
            {
                throw new LocationOutOfBoundException("The location of the rover is going out of the plateau boundary.");
            }

            Rover.Location.Point = targetLocation;
        }

        // This does not belongs here. Consider moving this control somewhere else.
        private bool ThrowIfLocationIsOutsideOfThePlateau(Point targetLocation)

        {
            if (targetLocation.XCoordinate > Rover.Plateau.Grid.XCoordinate || targetLocation.XCoordinate < 0)
                return true;

            if (targetLocation.YCoordinate > Rover.Plateau.Grid.YCoordinate || targetLocation.YCoordinate < 0)
                return true;

            return false;
        }


        public override void Execute()
        {
            cardinalDirectionRoutes[Rover.Location.CardinalDirection].Invoke();
        }

        private readonly Dictionary<CardinalDirection, Action> cardinalDirectionRoutes;
    }
}
