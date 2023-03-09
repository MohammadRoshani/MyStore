using MyStore.Application.Common.Interfaces;
using MyStore.Domain.Entities;
using MyStore.Domain.Enums;
using MyStore.Domain.Events;
using MediatR;

namespace MyStore.Application.Props.Commands.CreateTodoItem;

public record CreatePropCommand(string Title,string Value, PropType Type) : IRequest<int>
{
}

public class CreatePropCommandHandler : IRequestHandler<CreatePropCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreatePropCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreatePropCommand request, CancellationToken cancellationToken)
    {
        Prop entity = new()
        {
            Title = request.Title,
            Value = request.Value,
            Type = request.Type,
        };

        entity.AddDomainEvent(new PropCreatedEvent(entity));

        _context.Props.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
