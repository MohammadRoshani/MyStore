using MyStore.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace MyStore.Application.Commodities.EventHandlers;

public class CommodityCreatedEventHandler : INotificationHandler<CommodityCreatedEvent>
{
    private readonly ILogger<CommodityCreatedEventHandler> _logger;

    public CommodityCreatedEventHandler(ILogger<CommodityCreatedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(CommodityCreatedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("MyStore Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}
