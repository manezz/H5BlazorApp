using BCrypt.Net;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;

namespace H5BlazorApp.Codes
{
    public enum ReturnType
    {
        String,
        ByteArray
    }

    public class HashingHandler
    {
        public dynamic MD5Hashing(string textToHash, ReturnType outputType)
        {
            MD5 mD5 = MD5.Create();

            byte[] inputBytes = Encoding.ASCII.GetBytes(textToHash);
            byte[] hashedValue = mD5.ComputeHash(inputBytes);

            if (outputType == ReturnType.String)
            {
                return Convert.ToBase64String(hashedValue);
            }
            else if (outputType == ReturnType.ByteArray)
            {
                return hashedValue;
            }
            else
                return null;
        }

        public dynamic SHAHashing(string textToHash, ReturnType outputType)
        {
            SHA256 sHA256 = SHA256.Create();

            byte[] inputBytes = Encoding.ASCII.GetBytes(textToHash);
            byte[] hashedValue = sHA256.ComputeHash(inputBytes);

            if (outputType == ReturnType.String)
            {
                return Convert.ToBase64String(hashedValue);
            }
            else if (outputType == ReturnType.ByteArray)
            {
                return hashedValue;
            }
            else
                return null;
        }

        public dynamic HMACHashing(string textToHash, ReturnType outputType)
        {
            byte[] myKey = Encoding.ASCII.GetBytes("LennyText");
            byte[] inputBytes = Encoding.ASCII.GetBytes(textToHash);

            HMACSHA256 hmac = new HMACSHA256();
            hmac.Key = myKey;

            byte[] hashedValue = hmac.ComputeHash(inputBytes);

            if (outputType == ReturnType.String)
            {
                return Convert.ToBase64String(hashedValue);
            }
            else if (outputType == ReturnType.ByteArray)
            {
                return hashedValue;
            }
            else
                return null;
        }

        public dynamic PBKDF2Hashing(string textToHash, ReturnType outputType)
        {
            byte[] inputBytes = Encoding.ASCII.GetBytes(textToHash);
            byte[] salt = Encoding.ASCII.GetBytes("LennyText");
            var hashAlgorithm = new HashAlgorithmName("SHA256");
            int itirationer = 10;
            int outputLength = 32;

            byte[] hashedValue = Rfc2898DeriveBytes.Pbkdf2(inputBytes, salt, itirationer, hashAlgorithm, outputLength);

            if (outputType == ReturnType.String)
            {
                return Convert.ToBase64String(hashedValue);
            }
            else if (outputType == ReturnType.ByteArray)
            {
                return hashedValue;
            }
            else
                return null;
        }

        // BCrypt.Net-Next
        public dynamic BCryptHashing(string textToHash, ReturnType outputType)
        {
            //return BCrypt.Net.BCrypt.HashPassword(textToHash);

            //int workFactor = 10;
            //bool enhanceEntropy = true;
            //return BCrypt.Net.BCrypt.HashPassword(textToHash, workFactor, enhanceEntropy);

            string salt = BCrypt.Net.BCrypt.GenerateSalt();
            bool enhanceEntropy = true;
            HashType hashType = HashType.SHA256;
            string hashedPasswordString = BCrypt.Net.BCrypt.HashPassword(textToHash, salt, enhanceEntropy, hashType);

            if (outputType == ReturnType.String)
            {
                return hashedPasswordString;
            }
            else if (outputType == ReturnType.ByteArray)
            {
                return Encoding.ASCII.GetBytes(hashedPasswordString);
            }
            else
                return null;
        }

        public bool BCryptVerifyHashing(string textToHash, string hashedValueFromDb)
        {
            //return BCrypt.Net.BCrypt.Verify(textToHash, hashedValueFromDb);

            //bool enhanceEntropy = true;
            //return BCrypt.Net.BCrypt.Verify(textToHash, hashedValueFromDb, enhanceEntropy);

            bool enhanceEntropy = true;
            HashType hashType = HashType.SHA256;
            return BCrypt.Net.BCrypt.Verify(textToHash, hashedValueFromDb, enhanceEntropy, hashType);
        }
    }
}
