using System.Security.Cryptography;
using System.Text;

namespace OmegaGymServer.Application.Helper.Securtiy;

public class PasswordEncrypter
{
    public static void Encrpt(string password, out byte[] passwordHash, out byte[] passwordSalt)
    {
        using (var hmac = new HMACSHA512())
        {
            byte[] saltBytes = hmac.Key;
            byte[] hashBytes = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            passwordSalt = saltBytes;
            passwordHash = hashBytes;
        }


    }

    public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
    {

        using (var hmac = new HMACSHA512(passwordSalt))
        {
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != passwordHash[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}

