namespace MyStore.Domain.Events;

public class CommodityCreatedEvent : BaseEvent
{
    public CommodityCreatedEvent(Commodity item)
    {
        Item = item;
    }

    public Commodity Item { get; }
}
