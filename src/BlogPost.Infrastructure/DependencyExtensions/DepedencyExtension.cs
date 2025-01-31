using Microsoft.Extensions.DependencyInjection;
using BlogPost.Infrastructure.Repository;

namespace BlogPost.Infrastructure.DependencyExtensions;

public static class DepedencyExtension
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IBlogRepository, BlogRepository>();
        services.AddScoped<IReadOnlyBlogRepository, ReadOnlyBlogPostRepository>();
        services.AddScoped<IEventLogRepository, EventLogRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IReadonlyCategoryRepository, ReadonlyCategoryRepository>();
        return services;
    }
}

