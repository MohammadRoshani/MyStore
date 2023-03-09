using MyStore.Application.Common.Mappings;
using MyStore.Domain.Entities;

namespace MyStore.Application.Common.Models;

// Note: This is currently just used to demonstrate applying multiple IMapFrom attributes.
public class LookupDto : IMapFrom<Category>, IMapFrom<Commodity>
{
    public int Id { get; init; }

    public string Title { get; init; }
}
