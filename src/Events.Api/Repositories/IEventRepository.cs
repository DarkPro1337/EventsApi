namespace EventsApi.Repositories;

using System.Collections.Generic;
using System.Threading.Tasks;
using EventsApi.Models;

public interface IEventRepository
{
    Task<Event> Get(int id);
    Task<IEnumerable<Event>> GetAll();
    Task Add(Event @event);
    Task Delete(int id);
    Task Update(Event @event);
}