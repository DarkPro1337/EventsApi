namespace EventsApi.Controllers;

using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EventsApi.Dtos;
using EventsApi.Models;
using EventsApi.Repositories;

[ApiController]
[Route("[controller]")]
public class EventsController : ControllerBase
{
    private readonly IEventRepository repository;
    public EventsController(IEventRepository repository) =>
        this.repository = repository;

    [HttpGet("{id}")]
    public async Task<ActionResult<Event>> GetEvent(int id)
    {
        var @event = await repository.Get(id);
        return @event switch
        {
            null => NotFound(),
            _ => Ok(@event)
        };
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Event>>> GetEvents()
    {
        var events = await repository.GetAll();
        return Ok(events);
    }

    [HttpPost]
    public async Task<ActionResult> CreateEvent(CreateEventDto createEventDto)
    {
        Event @event = new()
        {
            Name = createEventDto.Name,
            Description = createEventDto.Description,
            Plan = createEventDto.Plan,
            Organizer = createEventDto.Organizer,
            Speaker = createEventDto.Speaker,
            EventTime = createEventDto.EventTime,
            EventPlace = createEventDto.EventPlace
        };

        await repository.Add(@event);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteEvent(int id)
    {
        await repository.Delete(id);
        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateProduct(int id, UpdateEventDto updateEventDto)
    {
        Event @event = new()
        {
            EventId = id,
            Name = updateEventDto.Name,
            Description = updateEventDto.Description,
            Plan = updateEventDto.Plan,
            Organizer = updateEventDto.Organizer,
            Speaker = updateEventDto.Speaker,
            EventTime = updateEventDto.EventTime,
            EventPlace = updateEventDto.EventPlace
        };

        await repository.Update(@event);
        return Ok();
    }
}