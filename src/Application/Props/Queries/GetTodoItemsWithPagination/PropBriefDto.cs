using MyStore.Application.Common.Mappings;
using MyStore.Domain.Entities;

namespace MyStore.Application.Props.Queries.GetTodoItemsWithPagination;

public class PropBriefDto : IMapFrom<Prop>
{
    public int Id { get; init; }
    public int CategoryId { get; init; }
    public string Title { get; init; }
    public bool IsActive { get; init; }
}
