using System.Threading;
using System.Threading.Tasks;
using FluentValidation.Results;
using MediatR;
using SE.Clientes.API.Application.Events;
using SE.Clientes.API.Models;
using SE.Core.Messages;

namespace SE.Clientes.API.Application.Commands
{
    public class ClienteCommandHandler : CommandHandler,
        IRequestHandler<RegistrarClienteCommand, ValidationResult>
    {

        private readonly IClienteRepository _clienteRepository;

        public ClienteCommandHandler(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<ValidationResult> Handle(RegistrarClienteCommand message, CancellationToken cancellationToken)
        {
            if (!message.EhValido()) return message.ValidationResult;

            var cliente = new Cliente(message.Id, message.Nome, message.Email, message.Cpf);

            // validacoes de negocio
            var clienteExistente = await _clienteRepository.ObterPorCpf(cliente.Cpf.Numero);

            if (clienteExistente != null) 
            {
                AdicionarErro("este CPF já está em uso.");
                return ValidationResult;
            }

            // persistir no banco
            _clienteRepository.Adicionar(cliente);

            // lancar um evento cliente ok!
            cliente.AdicionarEvento(new ClienteRegistradoEvent(message.Id, message.Nome, message.Email, message.Cpf));

            return await PersistirDados(_clienteRepository.UnitOfWork);
        }
    }
}
