using System.Globalization;
using CsvHelper;
using MyStore.Application.Categories.Queries.ExportTodos;
using MyStore.Application.Common.Interfaces;
using MyStore.Infrastructure.Files.Maps;

namespace MyStore.Infrastructure.Files;

public class CsvFileBuilder : ICsvFileBuilder
{
    public byte[] BuildCommoditiesFile(IEnumerable<CommodityRecord> records)
    {
        using MemoryStream memoryStream = new();
        using (StreamWriter streamWriter = new(memoryStream))
        {
            using CsvWriter csvWriter = new(streamWriter, CultureInfo.InvariantCulture);

            csvWriter.Context.RegisterClassMap<CommodityRecordMap>();
            csvWriter.WriteRecords(records);
        }

        return memoryStream.ToArray();
    }
}
