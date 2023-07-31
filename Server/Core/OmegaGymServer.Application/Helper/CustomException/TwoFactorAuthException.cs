using System.Runtime.Serialization;

namespace OmegaGymServer.Application.Helper.CustomException
{
    public class TwoFactorAuthException : Exception
    {
        public TwoFactorAuthException() : base("doğrulamada bilinmeyen bir hata oluştu. bilgileri kontrol edip tekrar deneyin")
        {
        }

        public TwoFactorAuthException(string message) : base(message)
        {
        }

        public TwoFactorAuthException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected TwoFactorAuthException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}