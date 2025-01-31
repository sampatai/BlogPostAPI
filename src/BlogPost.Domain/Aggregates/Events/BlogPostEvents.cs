namespace BlogPost.Domain.Aggregates.Events;

public record BlogPostAddedEvent(Guid BlogPostGuid, string Title) : INotification { }
public record BlogPostPublishedEvent(Guid BlogPostGuid, string Title) : INotification { }
