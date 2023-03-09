using MyStore.Application.Common.Exceptions;
using MyStore.Application.Common.Interfaces;
using MyStore.Domain.Entities;
using MediatR;

namespace MyStore.Application.Commodities.Commands.UpdateTodoItem;

public record UpdateCommodityCommand(int Id, string Title, bool IsActive) : IRequest
{
}

public class UpdateCommodityCommandHandler : IRequestHandler<UpdateCommodityCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateCommodityCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateCommodityCommand request, CancellationToken cancellationToken)
    {
        Commodity? entity = await _context.Commodities
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Commodity), request.Id);
        }

        entity.Title = request.Title;

        await _context.SaveChangesAsync(cancellationToken);
    }
}
