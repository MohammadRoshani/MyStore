using System.Globalization;
using CsvHelper.Configuration;
using MyStore.Application.Categories.Queries.ExportTodos;

namespace MyStore.Infrastructure.Files.Maps;

public class CommodityRecordMap : ClassMap<CommodityRecord>
{
    public CommodityRecordMap()
    {
        AutoMap(CultureInfo.InvariantCulture);

        Map(m => m.IsActive).Convert(c => c.Value.IsActive ? "Yes" : "No");
    }
}
