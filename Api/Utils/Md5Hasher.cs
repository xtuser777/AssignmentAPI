using System.Security.Cryptography;
using System.Text;

namespace Assignment.Api.Utils;

public class Md5Hasher
{
    public static string CreateMD5Hash(string input)
    {
        Byte[] byteDataToHash = Encoding.UTF8.GetBytes(input);
        Byte[] byteHashValue = MD5.HashData(byteDataToHash);
        StringBuilder s = new();
        foreach (var b in byteHashValue)
            s.Append(b.ToString("x2"));
        return s.ToString();
    }
}
