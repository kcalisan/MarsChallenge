using Nasa.Missions.Mars.DomaninModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nasa.Missions.Mars.DomainModel.Commands
{
    public class TurnRightCommand : RoboticRoverCommand
    {
        public TurnRightCommand(Rover rover)
            : base(rover)
        {
            CommandMapper = new RelativeDirectionMapper(rover);
        }

        public override void Execute()
        {
            CommandMapper.RightCommandCardinalRotationMatcher[Rover.Location.CardinalDirection].Invoke();
        }
        public readonly RelativeDirectionMapper CommandMapper;
    }
}
