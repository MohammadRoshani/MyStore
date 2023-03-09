using MyStore.Application.Categories.Queries.ExportTodos;

namespace MyStore.Application.Common.Interfaces;

public interface ICsvFileBuilder
{
    byte[] BuildCommoditiesFile(IEnumerable<CommodityRecord> records);
}
