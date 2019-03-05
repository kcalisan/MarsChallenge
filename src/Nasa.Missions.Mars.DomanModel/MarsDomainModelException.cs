using Nasa.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nasa.Missions.Mars.DomainModel
{
    public class MarsDomainModelException : NasaException
    {
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="MarsDomainModelException" /> class.
        /// </summary>
        public MarsDomainModelException()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="MarsDomainModelException" /> class.
        /// </summary>
        public MarsDomainModelException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="LocationOutOfBoundException" /> class.
        /// </summary>
        public MarsDomainModelException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
