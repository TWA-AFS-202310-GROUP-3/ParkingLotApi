using System.Runtime.Serialization;

namespace ParkingLotApi.Exceptions
{
    [Serializable]
    internal class UsedNameException : Exception
    {
        public UsedNameException()
        {
        }

        public UsedNameException(string? message) : base(message)
        {
        }

        public UsedNameException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected UsedNameException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}