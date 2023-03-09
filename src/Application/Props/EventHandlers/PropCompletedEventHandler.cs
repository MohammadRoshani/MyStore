using MyStore.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace MyStore.Application.Props.EventHandlers;

public class PropCompletedEventHandler : INotificationHandler<PropCompletedEvent>
{
    private readonly ILogger<PropCompletedEventHandler> _logger;

    public PropCompletedEventHandler(ILogger<PropCompletedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(PropCompletedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("MyStore Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}
