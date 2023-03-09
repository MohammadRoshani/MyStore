namespace MyStore.Domain.Events;

public class CommodityDeletedEvent : BaseEvent
{
    public CommodityDeletedEvent(Commodity item)
    {
        Item = item;
    }

    public Commodity Item { get; }
}
