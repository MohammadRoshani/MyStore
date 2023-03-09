using MyStore.Application.Common.Mappings;
using MyStore.Domain.Entities;

namespace MyStore.Application.Commodities.Queries.GetTodoItemsWithPagination;

public class CommodityBriefDto : IMapFrom<Commodity>
{
    public int Id { get; init; }

    public int CategoryId { get; init; }

    public string Title { get; init; }

    public bool IsActive { get; init; }
}
