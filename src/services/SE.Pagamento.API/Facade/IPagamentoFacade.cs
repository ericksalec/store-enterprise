using System.Threading.Tasks;
using SE.Pagamentos.API.Models;

namespace SE.Pagamentos.API.Facade
{
    public interface IPagamentoFacade
    {
        Task<Transacao> AutorizarPagamento(Pagamento pagamento);
    }
}
