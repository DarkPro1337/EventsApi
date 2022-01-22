namespace EventsApi.Data;

using Microsoft.EntityFrameworkCore;
using EventsApi.Models;

public class DataContext: DbContext, IDataContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
         
    }

    public DbSet<Event> Events { get; init; }
}