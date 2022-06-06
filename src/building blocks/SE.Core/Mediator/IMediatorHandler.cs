using System.Threading.Tasks;
using FluentValidation.Results;
using SE.Core.Messages;

namespace SE.Core.Mediator
{
    public interface IMediatorHandler
    {
        Task PublicarEventos<T>(T evento) where T : Event;
        Task<ValidationResult> EnviarComando<T>(T comando) where T : Command;
    }
}