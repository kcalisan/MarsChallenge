using Nasa.Missions.Mars.DomainModel.Builders;
using Nasa.Missions.Mars.DomainModel;
using System;
using System.Collections.Generic;
using System.Text;
using NSubstitute;
using NUnit.Framework;
using Nasa.Missions.Mars.DomaninModel;

namespace Nasa.Missions.Mars.Test
{
    public class RoverCommandParserTest
    {
        private IPlateauBuilder plateauBuilder;
        private IRoverBuilder roverBuilder;
        private IRoverCommandListBuilder roverCommandListBuilder;
        private StringBuilder arguments;

        [SetUp]
        public void Setup()
        {
            arguments = new StringBuilder();
            arguments.AppendLine("5 5");
            arguments.AppendLine("1 1 N");
            arguments.AppendLine("LMLMLM");
            arguments.AppendLine("2 2 S");
            arguments.AppendLine("RMLMR");

            plateauBuilder = Substitute.For<IPlateauBuilder>();
            roverBuilder = Substitute.For<IRoverBuilder>();
            roverCommandListBuilder = Substitute.For<IRoverCommandListBuilder>();
        }

        [Test]
        public void Line1_to_plateauBuilder()
        {
            IRoverCommandParser roverCommandParser = new RoverCommandParser(plateauBuilder, roverBuilder, roverCommandListBuilder);

            roverCommandParser.Parse(arguments.ToString());

            plateauBuilder.Received().Init("5 5");
        }

        [Test]
        public void Line2_roverBuilder()
        {
            IRoverCommandParser roverCommandParser = new RoverCommandParser(plateauBuilder, roverBuilder, roverCommandListBuilder);

            roverCommandParser.Parse(arguments.ToString());

            roverBuilder.Received().Init("1 1 N", Arg.Any<Plateau>());
        }

        [Test]
        public void Line3_to_RoverCommandListBuilder()
        {
            IRoverCommandParser roverCommandParser = new RoverCommandParser(plateauBuilder, roverBuilder, roverCommandListBuilder);

            roverCommandParser.Parse(arguments.ToString());

            roverCommandListBuilder.Received().Init(Arg.Any<Rover>(), "LMLMLM");
        }

        [Test]
        public void Line4_to_RoverBuilder()
        {
            IRoverCommandParser roverCommandParser = new RoverCommandParser(plateauBuilder, roverBuilder, roverCommandListBuilder);

            roverCommandParser.Parse(arguments.ToString());

            roverBuilder.Received().Init("2 2 S", Arg.Any<Plateau>());
        }

        [Test]
        public void Line5_to_RoverCommandListBuilder()
        {
            IRoverCommandParser roverCommandParser = new RoverCommandParser(plateauBuilder, roverBuilder, roverCommandListBuilder);

            roverCommandParser.Parse(arguments.ToString());

            roverCommandListBuilder.Received().Init(Arg.Any<Rover>(), "RMLMR");
        }
    }
}
