using System.Runtime.Serialization;

namespace HistoricalRatesDal
{
    [Serializable]
    public class ArchiveException : Exception
    {
        public ArchiveException()
        {
        }

        public ArchiveException(string? message) : base(message)
        {
        }

        public ArchiveException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected ArchiveException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}