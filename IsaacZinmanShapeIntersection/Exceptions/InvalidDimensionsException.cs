using System.Runtime.Serialization;

namespace ShapeIntersectionEngine.Exceptions
{
    [Serializable]
    public class InvalidDimensionsException : Exception
    {
        public InvalidDimensionsException()
        {
        }

        public InvalidDimensionsException(string? message) : base(message)
        {
        }

        public InvalidDimensionsException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected InvalidDimensionsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}