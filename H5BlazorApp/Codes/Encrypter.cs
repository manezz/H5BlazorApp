using System.Security.Cryptography;

namespace H5BlazorApp.Codes
{
    public class Encrypter
    {
        public static string Encrypt(string textToEncrypt, string publicKey)
        {
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                rsa.FromXmlString(publicKey);

                byte[] byteArrayTextToEncrypt = System.Text.Encoding.UTF8.GetBytes(textToEncrypt);
                byte[] encryptedData = rsa.Encrypt(byteArrayTextToEncrypt, true);
                return Convert.ToBase64String(encryptedData);
            }
        }
    }
}
