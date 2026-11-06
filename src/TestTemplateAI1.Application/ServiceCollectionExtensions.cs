using Microsoft.Extensions.DependencyInjection;
using TestTemplateAI1.Application.Pipelines;

namespace TestTemplateAI1.Application;

public static class ServiceCollectionExtensions
{
    public static void AddTestTemplateAI1ApplicationHandlers(this IServiceCollection services)
    {
        services.AddMediatR(config => config.RegisterServicesFromAssemblyContaining(typeof(ServiceCollectionExtensions)));
        services.AddPipelines();
        services.AddAutoMapper(typeof(ServiceCollectionExtensions).Assembly);
    }
}
