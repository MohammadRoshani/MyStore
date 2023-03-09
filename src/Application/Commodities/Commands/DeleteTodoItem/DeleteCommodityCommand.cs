using MyStore.Application.Common.Exceptions;
using MyStore.Application.Common.Interfaces;
using MyStore.Domain.Entities;
using MyStore.Domain.Events;
using MediatR;

namespace MyStore.Application.Commodities.Commands.DeleteTodoItem;

public record DeleteCommodityCommand(int Id) : IRequest;

public class DeleteCommodityCommandHandler : IRequestHandler<DeleteCommodityCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteCommodityCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(DeleteCommodityCommand request, CancellationToken cancellationToken)
    {
        Commodity? entity = await _context.Commodities
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Commodity), request.Id);
        }

        _context.Commodities.Remove(entity);

        entity.AddDomainEvent(new CommodityDeletedEvent(entity));

        await _context.SaveChangesAsync(cancellationToken);
    }
}
