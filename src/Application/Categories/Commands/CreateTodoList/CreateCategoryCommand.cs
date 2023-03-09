using MyStore.Application.Common.Interfaces;
using MyStore.Domain.Entities;
using MediatR;

namespace MyStore.Application.Categories.Commands.CreateTodoList;

public record CreateCategoryCommand : IRequest<int>
{
    public string Title { get; init; }
}

public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateCategoryCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        Category entity = new();

        entity.Title = request.Title;

        _context.Categories.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
