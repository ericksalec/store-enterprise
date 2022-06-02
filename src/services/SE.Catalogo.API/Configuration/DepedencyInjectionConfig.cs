using Microsoft.Extensions.DependencyInjection;
using SE.Catalogo.API.Data;
using SE.Catalogo.API.Data.Repository;
using SE.Catalogo.API.Models;

namespace SE.Catalogo.API.Configuration
{
    public static class DepedencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<CatalogoContext>();
        }
    }
}
