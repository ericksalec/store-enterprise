using System;
using System.Collections.Generic;
using System.Text;

namespace SE.DevPag
{
    public class DevPagService
    {
        public readonly string ApiKey;
        public readonly string EncryptionKey;

        public DevPagService(string apiKey, string encryptionKey)
        {
            ApiKey = apiKey;
            EncryptionKey = encryptionKey;
        }
    }
}
