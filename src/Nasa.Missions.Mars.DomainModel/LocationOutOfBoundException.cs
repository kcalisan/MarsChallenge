using Nasa.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nasa.Missions.Mars.DomainModel
{
    public class LocationOutOfBoundException : NasaException
    {
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="LocationOutOfBoundException" /> class.
        /// </summary>
        public LocationOutOfBoundException()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="MarsDomainModelException" /> class.
        /// </summary>
        public LocationOutOfBoundException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="LocationOutOfBoundException" /> class.
        /// </summary>
        public LocationOutOfBoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
