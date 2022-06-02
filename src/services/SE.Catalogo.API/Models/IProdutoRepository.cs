﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using SE.Core.Data;

namespace SE.Catalogo.API.Models
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        Task<IEnumerable<Produto>> ObterTodos();
        Task<Produto> ObterPorId(Guid id);

        void Adicionar(Produto produto);
        void Atualizar(Produto produto);
    }
}