using System.Threading.Tasks;
using SE.Pagamentos.API.Models;

namespace SE.Pagamentos.API.Facade
{
    public class PagamentoConfig
    {
        public string DefaultApiKey { get; set; }
        public string DefaultEncryptionKey { get; set; }
    }
}
