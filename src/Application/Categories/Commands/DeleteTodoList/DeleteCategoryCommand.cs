using MyStore.Application.Common.Exceptions;
using MyStore.Application.Common.Interfaces;
using MyStore.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MyStore.Application.Categories.Commands.DeleteTodoList;

public record DeleteCategoryCommand(int Id) : IRequest;

public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteCategoryCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        Category? entity = await _context.Categories
            .Where(l => l.Id == request.Id)
            .SingleOrDefaultAsync(cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Category), request.Id);
        }

        _context.Categories.Remove(entity);

        await _context.SaveChangesAsync(cancellationToken);
    }
}
