namespace BlogPost.Domain.Aggregates.Enumerations;
public class EventType : Enumeration
{
    public static EventType Added = new(1, nameof(Added));
    public static EventType Published = new(2, nameof(Published));
    
    public EventType(int id, string name) : base(id, name)
    {
    }
}

