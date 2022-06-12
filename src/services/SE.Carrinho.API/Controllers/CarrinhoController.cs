using Microsoft.AspNetCore.Authorization;
using SE.WebAPI.Core.Controllers;

namespace SE.Carrinho.API.Controllers
{
    [Authorize]
    public class CarrinhoController : MainController

    {
    }
}
