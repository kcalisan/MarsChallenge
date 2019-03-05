using FluentAssertions;
using Nasa.Missions.Mars.DomainModel;
using Nasa.Missions.Mars.DomainModel.Commands;
using Nasa.Missions.Mars.DomaninModel;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nasa.Missions.Mars.Test.Commands
{
    public class MoveForwardCommandTest
    {
        [Test]
        public void North_direction_rover()
        {
            var plateau = new Plateau(new Point(5, 5));
            var rover = new Rover(plateau, new Location(new Point(1, 2), CardinalDirection.North));
            RoboticRoverCommand command = new MoveForwardCommand(rover);

            command.Execute();

            rover.Location.Point.XCoordinate.Should().Be(1);
            rover.Location.Point.YCoordinate.Should().Be(3);
        }

        [Test]
        public void East_direction_rover()
        {
            var plateau = new Plateau(new Point(5, 5));
            var rover = new Rover(plateau, new Location(new Point(1, 2), CardinalDirection.East));
            RoboticRoverCommand command = new MoveForwardCommand(rover);

            command.Execute();

            rover.Location.Point.XCoordinate.Should().Be(2);
            rover.Location.Point.YCoordinate.Should().Be(2);
        }

        [Test]
        public void South_direction_rover()
        {
            var plateau = new Plateau(new Point(5, 5));
            var rover = new Rover(plateau, new Location(new Point(1, 2), CardinalDirection.South));
            RoboticRoverCommand command = new MoveForwardCommand(rover);

            command.Execute();

            rover.Location.Point.XCoordinate.Should().Be(1);
            rover.Location.Point.YCoordinate.Should().Be(1);
        }

        [Test]
        public void West_direction_rover()
        {
            var plateau = new Plateau(new Point(5, 5));
            var rover = new Rover(plateau, new Location(new Point(1, 2), CardinalDirection.West));
            RoboticRoverCommand command = new MoveForwardCommand(rover);

            command.Execute();

            rover.Location.Point.XCoordinate.Should().Be(0);
            rover.Location.Point.YCoordinate.Should().Be(2);
        }

        [Test]
        public void North_boundary_reaching_throws_location_out_of_bound_exception()
        {
            var plateau = new Plateau(new Point(0, 0));
            var rover = new Rover(plateau, new Location(new Point(0, 0), CardinalDirection.North));
            RoboticRoverCommand command = new MoveForwardCommand(rover);

            Action action = () => command.Execute();

            action.Should().ThrowExactly<LocationOutOfBoundException>();
        }

        [Test]
        public void East_boundary_reaching_throws_location_out_of_bound_exception()
        {
            var plateau = new Plateau(new Point(0, 0));
            var rover = new Rover(plateau, new Location(new Point(0, 0), CardinalDirection.East));
            RoboticRoverCommand command = new MoveForwardCommand(rover);

            Action action = () => command.Execute();

            action.Should().ThrowExactly<LocationOutOfBoundException>();
        }

        [Test]
        public void South_boundary_reaching_throws_location_out_of_bound_exception()
        {
            var plateau = new Plateau(new Point(0, 0));
            var rover = new Rover(plateau, new Location(new Point(0, 0), CardinalDirection.South));
            RoboticRoverCommand command = new MoveForwardCommand(rover);

            Action action = () => command.Execute();

            action.Should().ThrowExactly<LocationOutOfBoundException>();
        }

        [Test]
        public void West_boundary_reaching_throws_location_out_of_bound_exception()
        {
            var plateau = new Plateau(new Point(0, 0));
            var rover = new Rover(plateau, new Location(new Point(0, 0), CardinalDirection.West));
            RoboticRoverCommand command = new MoveForwardCommand(rover);

            Action action = () => command.Execute();

            action.Should().ThrowExactly<LocationOutOfBoundException>();
        }
    }
}
