namespace MyStore.Application.Categories.Queries.GetTodos;

public class ItemsVm
{
    public IReadOnlyCollection<CategoryDto> Lists { get; init; } = Array.Empty<CategoryDto>();
}
