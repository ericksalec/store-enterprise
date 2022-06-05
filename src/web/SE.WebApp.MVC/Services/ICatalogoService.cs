using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using SE.WebApp.MVC.Models;

namespace SE.WebApp.MVC.Services
{
    public interface ICatalogoService
    {
        Task<IEnumerable<ProdutoViewModel>> ObterTodos();
        Task<ProdutoViewModel> ObterPorId(Guid id);
    }
}