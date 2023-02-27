using System.Runtime.Serialization;

namespace ShapeIntersectionEngine.Exceptions
{
    [Serializable]
    public class NonNumericalInputException : Exception
    {
        public NonNumericalInputException()
        {
        }

        public NonNumericalInputException(string? message) : base(message)
        {
        }

        public NonNumericalInputException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected NonNumericalInputException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}