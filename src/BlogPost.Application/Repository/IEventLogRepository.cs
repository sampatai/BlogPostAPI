namespace BlogPost.Application.Repository;

public interface IEventLogRepository : IRepository<EventLogs>
{
    public Task<EventLogs> AddAsync(EventLogs eventLogs, CancellationToken cancellationToken);

}

