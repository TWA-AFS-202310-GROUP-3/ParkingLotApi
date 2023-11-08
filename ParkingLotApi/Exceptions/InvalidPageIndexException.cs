using System.Runtime.Serialization;

namespace ParkingLotApi.Exceptions
{
    [Serializable]
    internal class InvalidPageIndexException : Exception
    {
        public InvalidPageIndexException()
        {
        }

        public InvalidPageIndexException(string? message) : base(message)
        {
        }

        public InvalidPageIndexException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected InvalidPageIndexException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}