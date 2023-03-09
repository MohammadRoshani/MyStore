namespace MyStore.Domain.Events;

public class PropDeletedEvent : BaseEvent
{
    public PropDeletedEvent(Prop item)
    {
        Item = item;
    }

    public Prop Item { get; }
}
