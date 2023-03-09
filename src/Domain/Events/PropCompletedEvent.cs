namespace MyStore.Domain.Events;

public class PropCompletedEvent : BaseEvent
{
    public PropCompletedEvent(Prop item)
    {
        Item = item;
    }

    public Prop Item { get; }
}
