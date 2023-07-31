using System.Text;
using Microsoft.AspNetCore.WebUtilities;

namespace OmegaGymServer.Application.Helper;

public static class CustomCoding
{

    public static string TokenEncoding(this string value)
    {
        byte[] bytes = Encoding.UTF8.GetBytes(value);
        string resetToken = WebEncoders.Base64UrlEncode(bytes);
        return resetToken;
    }

    public static string TokenDecoding(this string value)
    {
        byte[] bytes = WebEncoders.Base64UrlDecode(value);
        string resetToken = Encoding.UTF8.GetString(bytes);
        return resetToken;
    }
}

