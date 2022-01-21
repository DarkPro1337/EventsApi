using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EventsApi.Models;

namespace EventsApi.Data
{
    public interface IDataContext
    {
        DbSet<Event> Events { get; init; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}