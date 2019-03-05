using FluentAssertions;
using Nasa.Missions.Mars.DomainModel.Builders;
using Nasa.Missions.Mars.DomaninModel;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nasa.Missions.Mars.Test.Builders
{
    public class PlateauBuilderTest
    {
            private IPlateauBuilder plateauBuilder;
            private string argument;

            [SetUp]
            public void Setup()
            {
                plateauBuilder = new PlateauBuilder();
                argument = "5 6";
            }

            [Test]
            public void PlateauBuilder_returns_expected_xcoordinate()
            {
                Plateau plateau = plateauBuilder.Init(argument);

                plateau.Grid.XCoordinate.Should().Be(5);
            }

            [Test]
            public void PlateauBuilder_returns_expected_ycoordinate()
            {
                Plateau plateau = plateauBuilder.Init(argument);

                plateau.Grid.YCoordinate.Should().Be(6);
            }

        public class Given_invalid_input_to_the_PlateauFactory
        {
            [TestCase("A 2")]
            [TestCase("1 A")]
            [TestCase("A A")]
            [TestCase("")]
            [TestCase("1")]
            [TestCase("1 1 1")]
            [TestCase("-1 1")]
            [TestCase("1 -1")]
            public void Create_returns_an_InvalidPlateauException(string argument)
            {
                var plateau = new PlateauBuilder();
                Action action = () => plateau.Init(argument);

                action.Should().Throw<ArgumentException>(); ;
            }
        }


    }
    }
