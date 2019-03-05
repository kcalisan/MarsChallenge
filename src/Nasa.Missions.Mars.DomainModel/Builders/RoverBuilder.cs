using System;
using System.Collections.Generic;
using System.Text;
using Nasa.Missions.Mars.DomaninModel;

namespace Nasa.Missions.Mars.DomainModel.Builders
{
    public class RoverBuilder : IRoverBuilder
    {
        public Rover Init(string arguments, Plateau plateau)
        {
            var roverArguments = arguments.Split(' ');

            if (roverArguments.Length != 3)
                throw new ArgumentException(string.Format($"Rover arguments {arguments} must consist of 3 elements"));

            for (int i = 0; i < 2; i++)
            {
                int coordinateOut;
                if (!int.TryParse(roverArguments[i], out coordinateOut))
                    throw new ArgumentException(string.Format($"Initial location arguments must be numeric number. {arguments}"));

                if (coordinateOut < 0)
                    throw new ArgumentException(string.Format($"Initial coordinate values must be greater than 0. {arguments}"));
            }

            var initialPoint = new Point(Convert.ToInt32(roverArguments[0]), Convert.ToInt32(roverArguments[1]));
            CardinalDirection cardinalDirection = RoverCardinalDirectionMapper.RoverCardinalDirectionMatcher[roverArguments[2]];

            var location = new Location(initialPoint, cardinalDirection);

            var rover = new Rover(plateau, location);

            return rover;
        }
    }
}
