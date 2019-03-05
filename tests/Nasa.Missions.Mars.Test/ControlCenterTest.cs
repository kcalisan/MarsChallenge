using System;
using System.Collections.Generic;
using System.Text;
using Nasa.Missions.Mars.DomainModel;
using NSubstitute;
using NUnit.Framework;

namespace Nasa.Missions.Mars.Test
{
    public class ControlCenterTest
    {
        private StringBuilder arguments;
        private IRoverCommandParser roverCommandParser;
        private ICommandInvoker commandInvoker;

        [SetUp]
        public void Setup()
        {
            arguments = new StringBuilder();
            arguments.AppendLine("5 5");
            arguments.AppendLine("1 1 N");
            arguments.AppendLine("LMLMLM");
            arguments.AppendLine("2 2 S");
            arguments.AppendLine("RMLMR");

            roverCommandParser = Substitute.For<IRoverCommandParser>();
            commandInvoker = Substitute.For<ICommandInvoker>();
        }

        [Test]
        public void LoadsRoversOfCommands_calls_the_RoverCommandParser()
        {
            IControlCenter controlCenter = new ControlCenter(roverCommandParser, commandInvoker);

            controlCenter.LoadsRoversOfCommands(arguments.ToString());

            roverCommandParser.ReceivedWithAnyArgs().Parse(Arg.Any<string>());
        }


    }
}
