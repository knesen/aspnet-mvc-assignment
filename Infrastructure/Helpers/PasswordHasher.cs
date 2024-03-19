using System.Security.Cryptography;
using System.Text;

namespace Infrastructure.Helpers;

public static class PasswordHasher
{
    public static (string, string) GenerateSecurePassword(string password)
    {
        try
        {
        using var hmac = new HMACSHA512();
        var securityKey = Convert.ToBase64String(hmac.Key);
        var computedHash = Convert.ToBase64String(hmac.ComputeHash(Encoding.UTF8.GetBytes(password)));
        
        return (securityKey, computedHash);

        }
        catch { }
        return (null!, null!);


    }

    public static bool ValidateSecurePassword(string password, string hashedPassword, string securityKey)
    {
        try
        {
            using var hmac = new HMACSHA512(Convert.FromBase64String(securityKey));
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            var hash = Convert.FromBase64String(hashedPassword);


            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != hash[i])
                    return false;
            }

            return true;

        }
        catch { }
        return false;
    }

}
