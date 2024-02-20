using Application.Bahaviors;
using Application.Commands.Pedido.Handlers;
using Application.Commands.Pedido.Validators;
using Application.Mappers;
using Domain.Contracts.Repository;
using FluentValidation;
using Infrastructure;
using Infrastructure.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CrossCutting;

public static class IoC
{
    public static void SetupApplication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAutoMapper(typeof(PedidoProfile).Assembly ??
                               throw new Exception("Falha ao inicializar Auto Mapper"));

        services.AddMediatR(c => { c.RegisterServicesFromAssembly(typeof(CreatePedidoHandler).Assembly); });
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));

        services.AddValidatorsFromAssemblyContaining<CreatePedidoCommandValidator>();
    }

    public static void SetupInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApiDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IPedidoRepository, PedidoRepository>();
    }
}