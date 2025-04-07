using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3.exception
{
    /// <summary>
    /// Exception thrown when an item cannot be removed from a list
    /// </summary>
    [Serializable]
    public class CannotRemoveException : Exception
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public CannotRemoveException() : base("Cannot remove item from the list") { }

        /// <summary>
        /// Constructor with custom message
        /// </summary>
        /// <param name="message">Custom error message</param>
        public CannotRemoveException(string message) : base(message) { }

        /// <summary>
        /// Constructor with custom message and inner exception
        /// </summary>
        /// <param name="message">Custom error message</param>
        /// <param name="innerException">Inner exception</param>
        public CannotRemoveException(string message, Exception innerException)
            : base(message, innerException) { }

        /// <summary>
        /// Serialization constructor
        /// </summary>
        /// <param name="info">Serialization information</param>
        /// <param name="context">Streaming context</param>
        protected CannotRemoveException(SerializationInfo info, StreamingContext context)
            : base(info, context) { }
    }
}
