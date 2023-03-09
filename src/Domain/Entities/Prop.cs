using MyStore.Domain.Enums;

namespace MyStore.Domain.Entities;

public class Prop : BaseAuditableEntity
{    public string Title { get; set; } = null!;

    public string Value { get; set; } = null!;

    public PropType Type { get; set; }

    public ICollection<CategoryProp> CategoryProp { get; } = new List<CategoryProp>();
}
