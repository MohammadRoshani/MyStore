namespace MyStore.Domain.Events;

public class PropCreatedEvent : BaseEvent
{
    public PropCreatedEvent(Prop item)
    {
        Item = item;
    }

    public Prop Item { get; }
}
