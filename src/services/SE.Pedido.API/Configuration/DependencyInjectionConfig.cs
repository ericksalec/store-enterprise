using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using SE.Core.Mediator;
using SE.Pedidos.API.Application.Queries;
using SE.Pedidos.Domain;
using SE.Pedidos.Domain.Pedidos;
using SE.Pedidos.Infra.Data;
using SE.Pedidos.Infra.Data.Repository;
using SE.WebAPI.Core.Usuario;

namespace SE.Pedidos.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            // API
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IAspNetUser, AspNetUser>();

            // Application
            services.AddScoped<IMediatorHandler, MediatorHandler>();
            services.AddScoped<IVoucherQueries, VoucherQueries>();

            // Data
            services.AddScoped<IVoucherRepository, VoucherRepository>();
            services.AddScoped<PedidosContext>();
        }

    }
}
