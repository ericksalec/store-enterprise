using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SE.WebApp.MVC.Controllers
{
    public class CarrinhoController : MainController
    {
        [Route("carrinho")]
        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpPost]
        [Route("carrinho/adicionar-item")]
        public async Task<IActionResult> AdicionarItemCarrinho()
        {
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("carrinho/atualizar-item")]
        public async Task<IActionResult> AtualizarItemCarrinho()
        {
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("carrinho/remover-item")]
        public async Task<IActionResult> RemoverItemCarrinho()
        {
            return RedirectToAction("Index");
        }

    }
}
