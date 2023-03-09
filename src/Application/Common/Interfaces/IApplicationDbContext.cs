using MyStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MyStore.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Category> Categories { get; }

    DbSet<Commodity> Commodities { get; }
    DbSet<Prop> Props { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
