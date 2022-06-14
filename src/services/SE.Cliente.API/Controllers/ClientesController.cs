using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SE.Clientes.API.Application.Commands;
using SE.Core.Mediator;
using SE.WebAPI.Core.Controllers;

namespace SE.Clientes.API.Controllers
{
    public class ClientesController : MainController
    {
        private readonly IMediatorHandler _mediatorHandler;

        public ClientesController(IMediatorHandler mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;
        }

        [HttpGet("cliente")]
        public async Task<IActionResult> Index()
        {
            var resultado = await _mediatorHandler.EnviarComando(
                new RegistrarClienteCommand(Guid.NewGuid(), "Teste2", "teste2@email.com", "44313480005"));

            return CustomResponse(resultado);
        }
    }
}
