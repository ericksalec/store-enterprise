using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SE.Core.Messages.Integration;
using SE.MessageBus;
using SE.Pedidos.API.Application.Queries;

namespace SE.Pedidos.API.Services
{
    public class PedidoOrquestradorIntegrationHandler : IHostedService, IDisposable
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<PedidoOrquestradorIntegrationHandler> _logger;
        private Timer _timer;

        public PedidoOrquestradorIntegrationHandler(ILogger<PedidoOrquestradorIntegrationHandler> logger,
            IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Serviço de pedidos iniciado.");

            _timer = new Timer(ProcessarPedidos, null, TimeSpan.Zero,
                TimeSpan.FromSeconds(15));

            return Task.CompletedTask;
        }

        private async void ProcessarPedidos(object state)
        {

        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Serviço de pedidos finalizado.");

            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}