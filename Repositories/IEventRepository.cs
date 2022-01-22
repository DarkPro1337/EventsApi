using System.Collections.Generic;
using System.Threading.Tasks;
using EventsApi.Models;

namespace EventsApi.Repositories
{
    public interface IEventRepository
    {
        Task<Event> Get(int id);
        Task<IEnumerable<Event>> GetAll();
        Task Add(Event evnt);
        Task Delete(int id);
        Task Update(Event evnt);
    }
}