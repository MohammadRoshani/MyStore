namespace MyStore.Domain.Entities;

public class Category : BaseAuditableEntity
{
    public string Title { get; set; } = null!;
    public ICollection<Commodity> Items { get; } = new List<Commodity>();
    public ICollection<CategoryProp> CategoryProp { get; } = new List<CategoryProp>();

}
