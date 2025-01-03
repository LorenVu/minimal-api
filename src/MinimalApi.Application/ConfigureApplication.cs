using System.Reflection;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using MinimalApi.Application.Common.Behaviors;
using MinimalApi.Infrastructure.Repositories;
using MinimalApi.Infrastructure.Repositories.Interfaces;
using MinimalApi.Infrastructure.Shared.Requests;

namespace MinimalApi.Application;

public static class ConfigureApplication
{
    public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services)
    {
        services
            .AddAutoMapper(Assembly.GetExecutingAssembly())
            .AddMediatR(cfg =>
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()))
            .AddTransient(typeof(IPipelineBehavior<,>), typeof(PerformanceBehaviour<,>))
            .AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>))
            .AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>))
            .AddValidatorsFromAssembly(Assembly.GetExecutingAssembly())
            .AddScoped<ICustomerRepository, CustomerRepository>()
            .AddScoped<IBankRepository, BankRepository>();
            
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        return services;
    }
}