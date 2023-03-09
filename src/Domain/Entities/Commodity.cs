namespace MyStore.Domain.Entities;

public class Commodity : BaseAuditableEntity
{
    public int CategoryId { get; set; }

    public string Code { get; set; } = null!;

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string ImageName { get; set; } = null!;

    public bool IsActive { get; set; }

    public Category Category { get; set; } = null!;
}
