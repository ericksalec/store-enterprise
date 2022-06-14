using System.Threading.Tasks;
using SE.Core.Data;

namespace SE.Pedidos.Domain
{
    public interface IVoucherRepository : IRepository<Voucher>
    {
        Task<Voucher> ObterVoucherPorCodigo(string codigo);
        void Atualizar(Voucher voucher);

    }
}
