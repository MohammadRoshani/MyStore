using MyStore.Application.Common.Interfaces;
using MediatR;

namespace MyStore.Application.Categories.Commands.PurgeTodoLists;

public record PurgeCategoriesCommand : IRequest;

public class PurgeCategoriesCommandHandler : IRequestHandler<PurgeCategoriesCommand>
{
    private readonly IApplicationDbContext _context;

    public PurgeCategoriesCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(PurgeCategoriesCommand request, CancellationToken cancellationToken)
    {
        _context.Categories.RemoveRange(_context.Categories);

        await _context.SaveChangesAsync(cancellationToken);
    }
}
