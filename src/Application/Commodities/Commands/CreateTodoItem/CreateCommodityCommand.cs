using MyStore.Application.Common.Interfaces;
using MyStore.Domain.Entities;
using MyStore.Domain.Events;
using MediatR;

namespace MyStore.Application.Commodities.Commands.CreateTodoItem;

public record CreateCommodityCommand(int CategoryId, string Code, string Title, string Description, string ImageName) : IRequest<int>
{
}

public class CreateCommodityCommandHandler : IRequestHandler<CreateCommodityCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateCommodityCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateCommodityCommand request, CancellationToken cancellationToken)
    {
        Commodity entity = new()
        {
            CategoryId = request.CategoryId,
            Title = request.Title,
            Description = request.Description,
            Code = request.Code,
            ImageName = request.ImageName
        };

        entity.AddDomainEvent(new CommodityCreatedEvent(entity));

        _context.Commodities.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
