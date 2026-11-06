using Microsoft.Extensions.DependencyInjection;
using TestTemplateAI1.Common.Interfaces;
using TestTemplateAI1.Core.Interfaces;
using TestTemplateAI1.Data.Repositories;

namespace TestTemplateAI1.Data;

public static class ServiceCollectionExtensions
{
    public static void AddSpecificRepositories(this IServiceCollection services) =>
        services.AddScoped<IFooRepository, FooRepository>();

    public static void AddGenericRepository(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
    }
}
