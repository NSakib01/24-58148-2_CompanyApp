using System.Security.Cryptography;
using System.Text;

namespace EmployeeDetails
{
    internal static class PasswordHelper
    {
        public static string ComputeSha256(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                // SQL Server HASHBYTES receives NVARCHAR values as UTF-16LE.
                byte[] passwordBytes = Encoding.Unicode.GetBytes(password);
                byte[] hashBytes = sha256.ComputeHash(passwordBytes);
                StringBuilder result = new StringBuilder(hashBytes.Length * 2);

                foreach (byte hashByte in hashBytes)
                {
                    result.Append(hashByte.ToString("x2"));
                }

                return result.ToString();
            }
        }
    }
}
