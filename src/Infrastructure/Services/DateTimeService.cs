using MyStore.Application.Common.Interfaces;

namespace MyStore.Infrastructure.Services;

public class DateTimeService : IDateTime
{
    public DateTime Now => DateTime.Now;
}
