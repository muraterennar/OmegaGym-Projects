using System.Runtime.Serialization;

namespace OmegaGymServer.Application.Helper.CustomException;

public class DatabaseValidationException : Exception
{
    public DatabaseValidationException()
    {
    }

    public DatabaseValidationException(string message) : base(message)
    {
    }

    public DatabaseValidationException(string message, Exception innerException) : base(message, innerException)
    {
    }

    protected DatabaseValidationException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}

