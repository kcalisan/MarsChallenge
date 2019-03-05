using Autofac;
using Nasa.Missions.Mars.DomainModel;
using Nasa.Missions.Mars.DomainModel.Builders;
using System;

namespace Nasa.Missions.Mars.CommandLine
{
    class Program
    {
        static void Main(string[] args)
        {
            RegisterServices();

            using (var scope = container.BeginLifetimeScope())
            {
                controlCenter = scope.Resolve<IControlCenter>();
                //use commands.txt file for testing.
                controlCenter.LoadsRoversOfCommands(ReadFile(args[0]));
                controlCenter.Execute();
                System.Console.Write(controlCenter.GetResult());
                System.Console.ReadKey();
            }
        }

        private static void RegisterServices()
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterType<PlateauBuilder>().As<IPlateauBuilder>();
            containerBuilder.RegisterType<RoverBuilder>().As<IRoverBuilder>();
            containerBuilder.RegisterType<RoverCommandListBuilder>().As<IRoverCommandListBuilder>();
            containerBuilder.Register<IRoverCommandParser>(
                c => new RoverCommandParser(
                        c.Resolve<IPlateauBuilder>(),
                        c.Resolve<IRoverBuilder>(),
                        c.Resolve<IRoverCommandListBuilder>()
                        ));
            containerBuilder.RegisterType<CommandInvoker>().As<ICommandInvoker>();
            containerBuilder.Register<IControlCenter>(
                c => new ControlCenter(
                        c.Resolve<IRoverCommandParser>(),
                        c.Resolve<ICommandInvoker>()
                        ));
            container = containerBuilder.Build();

        }

        private static string ReadFile(string filename)
        {
            string commands = System.IO.File.ReadAllText(filename);

            return commands;
        }

        private static IControlCenter controlCenter;
        private static IContainer container;
    }
}
