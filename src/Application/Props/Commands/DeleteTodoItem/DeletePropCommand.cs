using MyStore.Application.Common.Exceptions;
using MyStore.Application.Common.Interfaces;
using MyStore.Domain.Entities;
using MyStore.Domain.Events;
using MediatR;

namespace MyStore.Application.Props.Commands.DeleteTodoItem;

public record DeletePropCommand(int Id) : IRequest;

public class DeletePropCommandHandler : IRequestHandler<DeletePropCommand>
{
    private readonly IApplicationDbContext _context;

    public DeletePropCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(DeletePropCommand request, CancellationToken cancellationToken)
    {
        Prop? entity = await _context.Props
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Prop), request.Id);
        }

        _context.Props.Remove(entity);

        entity.AddDomainEvent(new PropDeletedEvent(entity));

        await _context.SaveChangesAsync(cancellationToken);
    }
}
