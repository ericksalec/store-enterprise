using System;
using SE.Core.Messages;

namespace SE.Clientes.API.Application.Commands
{
    public class RegistrarClienteCommand : Command
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Cpf { get; private set; }

        public RegistrarClienteCommand(Guid id, string name, string email, string cpf)
        {
            AggregateId = id;
            Id = id;
            Nome = name;
            Email = email;
            Cpf = cpf;
        }
    }
}
