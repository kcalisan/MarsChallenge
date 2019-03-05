using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using Nasa.Missions.Mars.DomainModel.Commands;
using Nasa.Missions.Mars.DomaninModel;
using NUnit.Framework;

namespace Nasa.Missions.Mars.Test.Commands
{
    public class TurnLeftCommandTests
    {
        [Test]
        public void North_direction_rover()
        {
            var plateau = new Plateau(new Point(5, 5));
            var rover = new Rover(plateau, new Location(new Point(1, 2), CardinalDirection.North));
            RoboticRoverCommand command = new TurnLeftCommand(rover);

            command.Execute();

            rover.Location.CardinalDirection.Should().Be(CardinalDirection.West);
        }

        [Test]
        public void East_direction_rover()
        {
            var plateau = new Plateau(new Point(5, 5));
            var rover = new Rover(plateau, new Location(new Point(1, 2), CardinalDirection.East));
            RoboticRoverCommand command = new TurnLeftCommand(rover);

            command.Execute();

            rover.Location.CardinalDirection.Should().Be(CardinalDirection.North);
        }
        [Test]
        public void South_direction_rover()
        {
            var plateau = new Plateau(new Point(5, 5));
            var rover = new Rover(plateau, new Location(new Point(1, 2), CardinalDirection.South));
            RoboticRoverCommand command = new TurnLeftCommand(rover);

            command.Execute();

            rover.Location.CardinalDirection.Should().Be(CardinalDirection.East);
        }

        [Test]
        public void West_direction_rover()
        {
            var plateau = new Plateau(new Point(5, 5));
            var rover = new Rover(plateau, new Location(new Point(1, 2), CardinalDirection.West));
            RoboticRoverCommand command = new TurnLeftCommand(rover);

            command.Execute();

            rover.Location.CardinalDirection.Should().Be(CardinalDirection.South);
        }
    }
}
