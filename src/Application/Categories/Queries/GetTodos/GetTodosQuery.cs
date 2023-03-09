using AutoMapper;
using AutoMapper.QueryableExtensions;
using MyStore.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MyStore.Application.Categories.Queries.GetTodos;

public record GetItemsQuery : IRequest<ItemsVm>;

public class GetItemsQueryHandler : IRequestHandler<GetItemsQuery, ItemsVm>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetItemsQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ItemsVm> Handle(GetItemsQuery request, CancellationToken cancellationToken)
    {
        return new ItemsVm
        {
            Lists = await _context.Categories
                .AsNoTracking()
                .ProjectTo<CategoryDto>(_mapper.ConfigurationProvider)
                .OrderBy(t => t.Title)
                .ToListAsync(cancellationToken)
        };
    }
}
