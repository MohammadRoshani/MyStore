namespace MyStore.Domain.Events;

public class CommodityCompletedEvent : BaseEvent
{
    public CommodityCompletedEvent(Commodity item)
    {
        Item = item;
    }

    public Commodity Item { get; }
}
