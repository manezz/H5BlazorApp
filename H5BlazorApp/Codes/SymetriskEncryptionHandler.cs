using Microsoft.AspNetCore.DataProtection;

namespace H5BlazorApp.Codes
{
    public class SymetriskEncryptionHandler
    {
        private readonly IDataProtector _protector;

        public SymetriskEncryptionHandler(IDataProtectionProvider protector)
        {
            _protector = protector.CreateProtector("LennyBenny");
        }

        public string EncryptData(string textEncrypt) =>
            _protector.Protect(textEncrypt);

        public string DencryptData(string textDencrypt) =>
            _protector.Unprotect(textDencrypt);
    }
}
