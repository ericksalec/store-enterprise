using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using SE.Carrinho.API.Data;
using SE.WebAPI.Core.Usuario;

namespace SE.Carrinho.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IAspNetUser, AspNetUser>();
            services.AddScoped<CarrinhoContext>();
        }
    }

}
