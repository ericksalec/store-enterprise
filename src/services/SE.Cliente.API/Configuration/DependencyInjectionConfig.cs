﻿using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using SE.Clientes.API.Application.Commands;
using SE.Clientes.API.Application.Events;
using SE.Clientes.API.Data;
using SE.Clientes.API.Data.Repository;
using SE.Clientes.API.Models;
using SE.Clientes.API.Services;
using SE.Core.Mediator;

namespace SE.Clientes.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IMediatorHandler, MediatorHandler>();
            services.AddScoped<IRequestHandler<RegistrarClienteCommand, ValidationResult>, ClienteCommandHandler>();

            services.AddScoped<INotificationHandler<ClienteRegistradoEvent>, ClienteEventHandler>();

            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<ClientesContext>();

            // HostedService => Singleton
            services.AddHostedService<RegistroClienteIntegrationHandler>();
        }
    }

}
