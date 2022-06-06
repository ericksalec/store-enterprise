using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace SE.Clientes.API.Application.Events
{
    public class ClienteEventHandler : INotificationHandler<ClienteRegistradoEvent>
    {
        public Task Handle(ClienteRegistradoEvent notification, CancellationToken cancellationToken)
        {
            // enviar evento de confirmacao
            return Task.CompletedTask;
        }

    }
}
