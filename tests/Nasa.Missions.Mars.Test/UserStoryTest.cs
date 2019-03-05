using FluentAssertions;
using Nasa.Missions.Mars.DomainModel;
using Nasa.Missions.Mars.DomainModel.Builders;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nasa.Missions.Mars.Test
{
    public class UserStoryTest
    {
        private ControlCenter controlCenter;

        [SetUp]
        public void Setup()
        {
            controlCenter = new ControlCenter(
                    new RoverCommandParser(
                        new PlateauBuilder(),
                        new RoverBuilder(),
                        new RoverCommandListBuilder()),
                    new CommandInvoker()
                );
        }

        [Test]
        public void Test_case()
        {
            var arguments = new StringBuilder();
            var expectedResult = new StringBuilder();

            arguments.AppendLine("5 5");
            arguments.AppendLine("1 2 N");
            arguments.AppendLine("LMLMLMLMM");
            arguments.AppendLine("3 3 E");
            arguments.AppendLine("MMRMMRMRRM");

            expectedResult.AppendLine("1 3 N");
            expectedResult.AppendLine("5 1 E");

            controlCenter.LoadsRoversOfCommands(arguments.ToString());
            controlCenter.Execute();
            var result = controlCenter.GetResult();

            result.Should().Be(expectedResult.ToString());
        }
    }
}
