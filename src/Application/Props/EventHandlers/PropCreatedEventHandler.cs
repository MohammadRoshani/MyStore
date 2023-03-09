using MyStore.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace MyStore.Application.Props.EventHandlers;

public class PropCreatedEventHandler : INotificationHandler<PropCreatedEvent>
{
    private readonly ILogger<PropCreatedEventHandler> _logger;

    public PropCreatedEventHandler(ILogger<PropCreatedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(PropCreatedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("MyStore Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}
