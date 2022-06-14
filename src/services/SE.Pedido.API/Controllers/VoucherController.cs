using Microsoft.AspNetCore.Authorization;
using SE.WebAPI.Core.Controllers;

namespace SE.Pedido.API.Controllers
{
    [Authorize]
    public class VoucherController : MainController
    {
    }
}
