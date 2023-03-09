using MyStore.Application.Common.Exceptions;
using MyStore.Application.Common.Interfaces;
using MyStore.Domain.Entities;
using MediatR;

namespace MyStore.Application.Categories.Commands.UpdateTodoList;

public record UpdateCategoryCommand : IRequest
{
    public int Id { get; init; }

    public string Title { get; init; }
}

public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateCategoryCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        Category? entity = await _context.Categories
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Category), request.Id);
        }

        entity.Title = request.Title;

        await _context.SaveChangesAsync(cancellationToken);
    }
}
