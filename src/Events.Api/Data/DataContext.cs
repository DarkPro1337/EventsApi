using Microsoft.EntityFrameworkCore;
using EventsApi.Models;

namespace EventsApi.Data
{
    public class DataContext: DbContext, IDataContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
             
        }

        public DbSet<Event> Events { get; init; }
    }
}