using AutoMapper;
using AutoMapper.QueryableExtensions;
using MyStore.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MyStore.Application.Categories.Queries.ExportTodos;

public record ExportItemsQuery : IRequest<ExportItemsVm>
{
    public int CategoryId { get; init; }
}

public class ExportItemsQueryHandler : IRequestHandler<ExportItemsQuery, ExportItemsVm>
{
    private readonly IApplicationDbContext _context;
    private readonly ICsvFileBuilder _fileBuilder;
    private readonly IMapper _mapper;

    public ExportItemsQueryHandler(IApplicationDbContext context, IMapper mapper, ICsvFileBuilder fileBuilder)
    {
        _context = context;
        _mapper = mapper;
        _fileBuilder = fileBuilder;
    }

    public async Task<ExportItemsVm> Handle(ExportItemsQuery request, CancellationToken cancellationToken)
    {
        List<CommodityRecord> records = await _context.Commodities
            .Where(t => t.CategoryId == request.CategoryId)
            .ProjectTo<CommodityRecord>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        ExportItemsVm vm = new(
            "Commodities.csv",
            "text/csv",
            _fileBuilder.BuildCommoditiesFile(records));

        return vm;
    }
}
