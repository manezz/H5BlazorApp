using System.Security.Cryptography;

namespace H5BlazorApp.Codes
{
    public class AsymetriskEncryptionHandler
    {
        private string _privateKey;
        private string _publicKey;

        public AsymetriskEncryptionHandler()
        {
            if (File.Exists("privateKey.pem") && File.Exists("privateKey.pem"))
            {
                _privateKey = File.ReadAllText("privateKey.pem");
                _publicKey = File.ReadAllText("publicKey.pem");
            }
            else
            {
                using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
                {
                    _privateKey = rsa.ToXmlString(true);
                    _publicKey = rsa.ToXmlString(false);

                    File.WriteAllText("privateKey.pem", _privateKey);
                    File.WriteAllText("publicKey.pem", _publicKey);
                }
            }
        }

        public string EncryptAsymetrisk(string textToEncrypt)
        {
            return Encrypter.Encrypt(textToEncrypt, _publicKey);
        }

        public string DecryptAsymetrisk(string textToDecrypt)
        {
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                rsa.FromXmlString(_privateKey);

                byte[] byteArraTextToDecrypt = Convert.FromBase64String(textToDecrypt);
                byte[] decryptedValue = rsa.Decrypt(byteArraTextToDecrypt, true);
                return System.Text.Encoding.UTF8.GetString(decryptedValue);
            };
        }
    }
}
