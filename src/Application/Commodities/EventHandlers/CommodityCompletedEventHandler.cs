using MyStore.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace MyStore.Application.Commodities.EventHandlers;

public class CommodityCompletedEventHandler : INotificationHandler<CommodityCompletedEvent>
{
    private readonly ILogger<CommodityCompletedEventHandler> _logger;

    public CommodityCompletedEventHandler(ILogger<CommodityCompletedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(CommodityCompletedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("MyStore Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}
