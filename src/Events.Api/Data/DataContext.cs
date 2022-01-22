namespace EventsApi.Data;

using Microsoft.EntityFrameworkCore;
using EventsApi.Models;

public class DataContext : DbContext, IDataContext
{
    public DbSet<Event> Events { get; init; }

    public DataContext(DbContextOptions<DataContext> options)
        : base(options)
    {
    }
}