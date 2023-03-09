using AutoMapper;
using AutoMapper.QueryableExtensions;
using MyStore.Application.Common.Interfaces;
using MyStore.Application.Common.Mappings;
using MyStore.Application.Common.Models;
using MediatR;

namespace MyStore.Application.Props.Queries.GetTodoItemsWithPagination;

public record GetPropsWithPaginationQuery : IRequest<PaginatedList<PropBriefDto>>
{
    public int CategoryId { get; init; }
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class
    GetPropsWithPaginationQueryHandler : IRequestHandler<GetPropsWithPaginationQuery,
        PaginatedList<PropBriefDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetPropsWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<PropBriefDto>> Handle(GetPropsWithPaginationQuery request,
        CancellationToken cancellationToken)
    {
        return await _context.Props
            .ProjectTo<PropBriefDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}
