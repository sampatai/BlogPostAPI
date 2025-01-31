namespace BlogPost.Application.DomainEvents
{
    public class BlogPostAddedEventHandler : INotificationHandler<BlogPostAddedEvent>
    {
        private readonly ILogger<BlogPostAddedEventHandler> _logger;
        private readonly IEventLogRepository _eventLogRepository;
        public BlogPostAddedEventHandler(ILoggerFactory logger,
        IEventLogRepository eventLogRepository)
        {
            _logger = logger.CreateLogger<BlogPostAddedEventHandler>();
            _eventLogRepository = eventLogRepository;
        }

        public async Task Handle(BlogPostAddedEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogTrace($"BlogPost: {notification.BlogPostGuid} has been created.");

            try
            {
                var description = $"Added:New BlogPost {notification.Title} added";
                EventLogs eventLog = new(description, EventType.Added);
                await _eventLogRepository.AddAsync(eventLog, cancellationToken);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{@notification}", notification);
                throw;
            }
        }
    }
    public class BlogPostPublishedEventHandler : INotificationHandler<BlogPostPublishedEvent>
    {
        private readonly ILogger<BlogPostPublishedEventHandler> _logger;
        private readonly IEventLogRepository _eventLogRepository;
        public BlogPostPublishedEventHandler(ILoggerFactory logger,
        IEventLogRepository eventLogRepository)
        {
            _logger = logger.CreateLogger<BlogPostPublishedEventHandler>();
            _eventLogRepository = eventLogRepository;
        }

        public async Task Handle(BlogPostPublishedEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogTrace($"BlogPost: {notification.BlogPostGuid} has been published.");

            try
            {
                var description = $"published: {notification.Title} published";
                EventLogs eventLog = new(description, EventType.Published);
                await _eventLogRepository.AddAsync(eventLog, cancellationToken);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{@notification}", notification);
                throw;
            }
        }
    }
}