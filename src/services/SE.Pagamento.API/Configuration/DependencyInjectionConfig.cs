using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using SE.Pagamentos.API.Data;
using SE.Pagamentos.API.Data.Repository;
using SE.Pagamentos.API.Models;
using SE.WebAPI.Core.Usuario;

namespace SE.Pagamentos.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IAspNetUser, AspNetUser>();

            services.AddScoped<IPagamentoRepository, PagamentoRepository>();
            services.AddScoped<PagamentosContext>();
        }
    }
}
