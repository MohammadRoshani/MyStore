using MyStore.Application.Common.Mappings;
using MyStore.Domain.Entities;

namespace MyStore.Application.Categories.Queries.GetTodos;

public class CategoryDto : IMapFrom<Category>
{
    public CategoryDto()
    {
        Items = Array.Empty<CommodityDto>();
    }

    public int Id { get; init; }

    public string Title { get; init; }

    public string? Colour { get; init; }

    public IReadOnlyCollection<CommodityDto> Items { get; init; }
}
