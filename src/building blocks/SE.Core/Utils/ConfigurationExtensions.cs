﻿using Microsoft.Extensions.Configuration;

namespace SE.Core.Utils
{
    public static class ConfigurationExtensions
    {
        public static string GetMessageConnection(this IConfiguration configuration, string name)
        {
            return configuration?.GetSection("MessageQueueConnection")?[name];
        }
    }
}
