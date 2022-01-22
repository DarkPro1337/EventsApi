namespace EventsApi.Repositories;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EventsApi.Data;
using EventsApi.Models;

public class EventRepository : IEventRepository
{
    private readonly IDataContext context;
    public EventRepository(IDataContext context) =>
        this.context = context;

    public async Task Add(Event @event)
    {        
        context.Events.Add(@event);
        await context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var itemToRemove = await context.Events.FindAsync(id);
        if (itemToRemove is null)
            throw new NullReferenceException();

        context.Events.Remove(itemToRemove);
        await context.SaveChangesAsync();
    }

    public async Task<Event> Get(int id) =>
        await context.Events.FindAsync(id);

    public async Task<IEnumerable<Event>> GetAll() =>
        await context.Events.ToListAsync();

    public async Task Update(Event @event)
    {
        var itemToUpdate = await context.Events.FindAsync(@event.EventId);
        if (itemToUpdate is null)
            throw new NullReferenceException();
        itemToUpdate.Name = @event.Name;
        itemToUpdate.Description = @event.Description;
        itemToUpdate.Plan = @event.Plan;
        itemToUpdate.Organizer = @event.Organizer;
        itemToUpdate.Speaker = @event.Speaker;
        itemToUpdate.EventTime = @event.EventTime;
        itemToUpdate.EventPlace = @event.EventPlace;
        await context.SaveChangesAsync();
    }
}