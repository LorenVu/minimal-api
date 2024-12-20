using Microsoft.Extensions.DependencyInjection.Extensions;
using MinimalProject.Endpoints;

namespace MinimalProject.Extensions;

public static class EndpointExtensions
{
    public static IServiceCollection AddMinimalEndpoints(this IServiceCollection services)
    {
        var assembly = typeof(Program).Assembly;
        var serviceDescriptors = assembly
            .DefinedTypes
            .Where(type => !type.IsAbstract &&
                           !type.IsInterface &&
                           type.IsAssignableTo(typeof(IEndpoint)))
            .Select(type => ServiceDescriptor.Transient(typeof(IEndpoint), type));

        services.TryAddEnumerable(serviceDescriptors);

        return services;
    }

    public static IApplicationBuilder RegisterMinimalEndpoints(this WebApplication app)
    {
        var endpoints = app.Services.GetRequiredService<IEnumerable<IEndpoint>>();

        var groupedEndpoints = endpoints
            .GroupBy(endpoint => new { endpoint.Version, endpoint.Group });
        
        foreach (var group in groupedEndpoints)
        {
            var routePrefix = $"/{group.Key.Version}/{group.Key.Group}";
            var groupBuilder = app.MapGroup(routePrefix);
            
            foreach (var endpoint in group)
            {
                endpoint.MapEndpoint(groupBuilder);
            }
        }

        return app;
    }
}