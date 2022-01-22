using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EventsApi.Data;
using EventsApi.Models;

namespace EventsApi.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly IDataContext _context;
        public EventRepository(IDataContext context) {
            _context = context;
        }

        public async Task Add(Event evnt) {        
            _context.Events.Add(evnt);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id) {
            var itemToRemove = await _context.Events.FindAsync(id);
            if (itemToRemove == null)
                throw new NullReferenceException();

            _context.Events.Remove(itemToRemove);
            await _context.SaveChangesAsync();
        }

        public async Task<Event> Get(int id) {
            return await _context.Events.FindAsync(id);
        }

        public async Task<IEnumerable<Event>> GetAll() {
            return await _context.Events.ToListAsync();
        }

        public async Task Update(Event evnt) {
            var itemToUpdate = await _context.Events.FindAsync(evnt.EventId);
            if (itemToUpdate == null)
                throw new NullReferenceException();
            itemToUpdate.Name = evnt.Name;
            itemToUpdate.Description = evnt.Description;
            itemToUpdate.Plan = evnt.Plan;
            itemToUpdate.Organizer = evnt.Organizer;
            itemToUpdate.Speaker = evnt.Speaker;
            itemToUpdate.EventTime = evnt.EventTime;
            itemToUpdate.EventPlace = evnt.EventPlace;
            await _context.SaveChangesAsync();
    
        }
    }
}