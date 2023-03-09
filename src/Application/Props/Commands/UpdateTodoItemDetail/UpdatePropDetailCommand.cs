using MyStore.Application.Common.Exceptions;
using MyStore.Application.Common.Interfaces;
using MyStore.Domain.Entities;
using MyStore.Domain.Enums;
using MediatR;

namespace MyStore.Application.Props.Commands.UpdateTodoItemDetail;

public record UpdatePropDetailCommand(int Id, string Title,string Value, PropType Type) : IRequest;

public class UpdatePropDetailCommandHandler : IRequestHandler<UpdatePropDetailCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdatePropDetailCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdatePropDetailCommand request, CancellationToken cancellationToken)
    {
        Prop? entity = await _context.Props
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Prop), request.Id);
        }

        entity.Title = request.Title;
        entity.Value = request.Value;
        entity.Type = request.Type;

        await _context.SaveChangesAsync(cancellationToken);
    }
}
