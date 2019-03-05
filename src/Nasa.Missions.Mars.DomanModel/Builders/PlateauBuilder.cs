using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nasa.Missions.Mars.DomaninModel;

namespace Nasa.Missions.Mars.DomainModel.Builders
{
    public class PlateauBuilder : IPlateauBuilder
    {
        public Plateau Init(string arguments)
        {
            var characters = TrimAndValidate(arguments);

            return new Plateau(new Point(Convert.ToInt32(characters[0]), Convert.ToInt32(characters[1])));
        }

        private string[] TrimAndValidate(string arguments)
        {
            string[] plateauArguments = arguments.Trim().Split(' ');

            CheckInput(arguments, plateauArguments);

            return plateauArguments;
        }

        private static void CheckInput(string arguments, string[] plateauArguments)
        {
            CheckValidInteger(arguments, plateauArguments);

            CheckPlateauArgumentsLength(arguments, plateauArguments);
        }

        private static void CheckPlateauArgumentsLength(string arguments, string[] plateauArguments)
        {
            if (plateauArguments.Count() != 2)
                throw new ArgumentException($"Plateau argument must contain 2 elements.{arguments}");
        }

        private static void CheckValidInteger(string arguments, string[] plateauArguments)
        {
            int parseOut;

            if (plateauArguments.Any(p => !int.TryParse(p, out parseOut)))
                throw new ArgumentException($"Plateau arguments contains invalid characters. {arguments}");

            if (plateauArguments.Any(p =>
            {
                int.TryParse(p, out parseOut);
                return parseOut < 1;
            }))
                throw new ArgumentException($"Plateau arguments cannot be negative number. {arguments}");
        }
    }
}
