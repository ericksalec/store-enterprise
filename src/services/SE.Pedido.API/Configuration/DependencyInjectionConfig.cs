using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using SE.Pedidos.Domain;
using SE.Pedidos.Domain.Pedidos;
using SE.Pedidos.Infra.Data;
using SE.WebAPI.Core.Usuario;

namespace SE.Pedido.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            // API
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IAspNetUser, AspNetUser>();


            // Data
            services.AddScoped<PedidosContext>();
        }

    }
}
