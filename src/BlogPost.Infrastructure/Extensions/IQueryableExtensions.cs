
using System.Linq.Expressions;

namespace BlogPost.Infrastructure.Extensions;


public static class IQueryableExtensions
{
    public static IQueryable<T> WhereIf<T>(this IQueryable<T> source, bool condition, Func<T, bool> predicate)
    {
        return condition ? source.Where(predicate).AsQueryable() : source;
    }

    public static IQueryable<T> SortBy<T>(
        this IQueryable<T> source,
        string? propertyName = null,
        string sortDirection = "asc")
    {
        if (source == null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        if (string.IsNullOrWhiteSpace(propertyName))
        {
            return source; // No sorting if property name is not provided
        }

        // Create a parameter expression for the entity type (T)
        var parameter = Expression.Parameter(typeof(T), "x");

        // Create a property access expression (x.PropertyName)
        var property = Expression.Property(parameter, propertyName);

        // Create a lambda expression (x => x.PropertyName)
        var lambda = Expression.Lambda(property, parameter);

        // Determine the sorting method (OrderBy or OrderByDescending)
        string methodName = string.Equals(sortDirection, SortHelper.Desc.Name, StringComparison.OrdinalIgnoreCase)
            ? SortHelper.OrderByDescending.Name
            : SortHelper.OrderBy.Name;

        // Create a method call expression (source.OrderBy(x => x.PropertyName))
        var methodCallExpression = Expression.Call(
            typeof(Queryable),
            methodName,
            new[] { typeof(T), property.Type },
            source.Expression,
            Expression.Quote(lambda)
        );

        // Apply the sorting and return the result
        return source.Provider.CreateQuery<T>(methodCallExpression);
    }
}