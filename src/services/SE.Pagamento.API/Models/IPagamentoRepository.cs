using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SE.Core.Data;

namespace SE.Pagamentos.API.Models
{
    public interface IPagamentoRepository : IRepository<Pagamento>
    {
        void AdicionarPagamento(Pagamento pagamento);
 
    }
}
