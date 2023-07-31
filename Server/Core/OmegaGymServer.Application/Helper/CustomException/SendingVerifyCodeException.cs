using System;
using System.Runtime.Serialization;

namespace OmegaGymServer.Application.Helper.CustomException
{
    public class SendingVerifyCodeException : Exception
    {
        public SendingVerifyCodeException() : base("Doğrulama Kodu Oluşturmada Bir Hata Oluştu")
        {
        }

        public SendingVerifyCodeException(string message) : base(message)
        {
        }

        public SendingVerifyCodeException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected SendingVerifyCodeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}

