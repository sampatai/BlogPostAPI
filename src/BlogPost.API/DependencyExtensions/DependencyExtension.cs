using Microsoft.EntityFrameworkCore;
using BlogPost.Infrastructure;


namespace BlogPost.API.DependencyExtensions
{
    public static class DependencyExtension
    {
        public static IServiceCollection AddBlogPosts(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BlogPostDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("BlogPostDbContext"),
                    sqlServerOptionsAction: sqlOptions =>
                    {
                        sqlOptions.EnableRetryOnFailure(maxRetryCount: 15, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
                    });
            },
           ServiceLifetime.Scoped);


            return services;
        }

    }
}
