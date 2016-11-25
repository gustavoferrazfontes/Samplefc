using System;
using SampleFC.RegisterAuthentication.Core.Domain.Model.UserAggregate.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace SampleFC.RegisterAuthentication.Core.Domain.Model.UserAggregate
{
    public class EncryptionService : IEncryptionService
    {


        public string GenereteEncryption(string password)
        {
            var bytes = Encoding.Unicode.GetBytes(password);
            var inArray = HashAlgorithm.Create("SHA1").ComputeHash(bytes);
            return Convert.ToBase64String(inArray);
        }

        
    }
}

