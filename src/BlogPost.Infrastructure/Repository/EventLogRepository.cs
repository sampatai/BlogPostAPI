namespace BlogPost.Infrastructure.Repository;

public class EventLogRepository(BlogPostDbContext BlogPostDbContext,
    ILogger<EventLogRepository> logger) : IEventLogRepository
{
    public IUnitOfWork UnitOfWork => BlogPostDbContext;

    public async Task<EventLogs> AddAsync(EventLogs eventLogs, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await BlogPostDbContext.EventLogs.AddAsync(eventLogs);
            return entity.Entity;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "@{eventLogs}", eventLogs);
            throw;
        }
    }
}

