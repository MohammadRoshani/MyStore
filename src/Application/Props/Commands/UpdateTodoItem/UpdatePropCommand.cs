using MyStore.Application.Common.Exceptions;
using MyStore.Application.Common.Interfaces;
using MyStore.Domain.Entities;
using MediatR;

namespace MyStore.Application.Props.Commands.UpdateTodoItem;

public record UpdatePropCommand(int Id, string Title, bool IsActive) : IRequest
{
}

public class UpdatePropCommandHandler : IRequestHandler<UpdatePropCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdatePropCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdatePropCommand request, CancellationToken cancellationToken)
    {
        Prop? entity = await _context.Props
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Prop), request.Id);
        }

        entity.Title = request.Title;

        await _context.SaveChangesAsync(cancellationToken);
    }
}
