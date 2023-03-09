using MyStore.Application.Common.Exceptions;
using MyStore.Application.Common.Interfaces;
using MyStore.Domain.Entities;
using MediatR;

namespace MyStore.Application.Commodities.Commands.UpdateTodoItemDetail;

public record UpdateCommodityDetailCommand(int Id, int CategoryId, string Code, string Title, string ImageName,
    string Description, bool IsActive) : IRequest;

public class UpdateCommodityDetailCommandHandler : IRequestHandler<UpdateCommodityDetailCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateCommodityDetailCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateCommodityDetailCommand request, CancellationToken cancellationToken)
    {
        Commodity? entity = await _context.Commodities
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Commodity), request.Id);
        }

        entity.CategoryId = request.CategoryId;
        entity.Title = request.Title;
        entity.ImageName = request.ImageName;
        entity.Description = request.Description;
        entity.Code = request.Code;
        entity.IsActive = request.IsActive;

        await _context.SaveChangesAsync(cancellationToken);
    }
}
