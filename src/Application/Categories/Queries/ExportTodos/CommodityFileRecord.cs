using MyStore.Application.Common.Mappings;
using MyStore.Domain.Entities;

namespace MyStore.Application.Categories.Queries.ExportTodos;

public class CommodityRecord : IMapFrom<Commodity>
{
    public string Title { get; init; }

    public bool IsActive { get; init; }
}
