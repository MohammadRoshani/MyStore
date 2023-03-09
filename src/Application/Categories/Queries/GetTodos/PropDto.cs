using AutoMapper;
using MyStore.Application.Common.Mappings;
using MyStore.Domain.Entities;

namespace MyStore.Application.Categories.Queries.GetTodos;

public class PropDto : IMapFrom<Prop>
{
    public int Id { get; set; }

    public int CategoryId { get; set; }

    public string Code { get; set; } = null!;

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string ImageName { get; set; } = null!;

    public bool IsActive { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Prop, PropDto>();
    }
}
