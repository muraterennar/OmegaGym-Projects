using System.Runtime.Serialization;

namespace OmegaGymServer.Application.Helper.CustomException;

public class PasswordChanceFailedException : Exception
{
    public PasswordChanceFailedException() : base("Şifre Güncellenirken Beklenemeyen Bir Hata Oluştu")
    {
    }

    public PasswordChanceFailedException(string message) : base(message)
    {
    }

    public PasswordChanceFailedException(string message, Exception innerException) : base(message, innerException)
    {
    }

    protected PasswordChanceFailedException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}

