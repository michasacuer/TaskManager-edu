using System;
using System.Runtime.Serialization;

namespace TaskManager.WPF
{
    [Serializable]
    internal class InternalServerException : Exception
    {
        public InternalServerException()
        {
        }

        public InternalServerException(string message) : base(message)
        {
        }

        public InternalServerException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InternalServerException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}