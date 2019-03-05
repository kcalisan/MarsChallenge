using System;
using System.Collections.Generic;
using System.Text;

namespace Nasa.Core
{
    /// <summary>
    /// Serves as the base exception class for Nasa library exceptions.
    /// </summary>
    public class NasaException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NasaException" />
        /// class.
        /// </summary>
        public NasaException()
            : base()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NasaException" />
        /// class.
        /// </summary>
        public NasaException(string message)
            : base(message)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NasaException" />
        /// class.
        /// </summary>
        public NasaException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}
