using Assignment.Api.Interfaces.Services;
using Assignment.Api.Utils;

namespace Assignment.Api.Services;

public class CryptService : ICryptService
{
    public string HashPassword(string password)
    {
        return Md5Hasher.CreateMD5Hash(password);
    }

    private static bool ByteArraysEqual(byte[] b1, byte[] b2)
    {
        if (b1 == b2) return true;
        if (b1.Length != b2.Length) return false;
        return !b1.Where((t, i) => t != b2[i]).Any();
    }

    public bool VerifyHashedPassword(string hashedPassword, string password)
    {
        var encryptedData = Convert.FromBase64String(hashedPassword);
        var keyStr = HashPassword(password);
        var key = Convert.FromBase64String(keyStr);

        return ByteArraysEqual(encryptedData, key);
    }
}
