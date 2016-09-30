using System.Security.Cryptography;
using System.Text;

namespace AutoFP.SharedKernel.ValueObjects.Validation
{
    public class PasswordAssertionConcern
    {
        public static string Encrypt(string password)
        {
            password += "SALT_KEY_HERE"; // TODO: Inserir SALT_KEY
            MD5 md5 = MD5.Create();
            byte[] data = md5.ComputeHash(Encoding.Default.GetBytes(password));
            StringBuilder sbString = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
                sbString.Append(data[i].ToString("x2"));
            return sbString.ToString();
        }
    }
}