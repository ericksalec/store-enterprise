using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SE.Clientes.API.Services;
using SE.Core.Utils;
using SE.MessageBus;

namespace SE.Clientes.API.Configuration
{
    public static class MessageBusConfig
    {
        public static void AddMessageBusConfiguration(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddMessageBus(configuration.GetMessageConnection("MessageBus"))
            // HostedService => Singleton
            .AddHostedService<RegistroClienteIntegrationHandler>(); 
        }
    }
}
