using AutoMapper;
using AutoMapper.QueryableExtensions;
using MyStore.Application.Common.Interfaces;
using MyStore.Application.Common.Mappings;
using MyStore.Application.Common.Models;
using MediatR;

namespace MyStore.Application.Commodities.Queries.GetTodoItemsWithPagination;

public record GetCommoditiesWithPaginationQuery : IRequest<PaginatedList<CommodityBriefDto>>
{
    public int CategoryId { get; init; }
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class
    GetCommoditiesWithPaginationQueryHandler : IRequestHandler<GetCommoditiesWithPaginationQuery,
        PaginatedList<CommodityBriefDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetCommoditiesWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<CommodityBriefDto>> Handle(GetCommoditiesWithPaginationQuery request,
        CancellationToken cancellationToken)
    {
        return await _context.Commodities
            .Where(x => x.CategoryId == request.CategoryId)
            .OrderBy(x => x.Title)
            .ProjectTo<CommodityBriefDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}
