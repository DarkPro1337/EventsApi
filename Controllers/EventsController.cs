using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EventsApi.Dtos;
using EventsApi.Models;
using EventsApi.Repositories;

namespace EventsApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventsController : ControllerBase
    {
        private readonly IEventRepository _eventRepository;
        public EventsController(IEventRepository eventRepository) {
            _eventRepository = eventRepository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Event>> GetEvent(int id) {
            var evnt = await _eventRepository.Get(id);
            if(evnt == null)
                return NotFound();
    
            return Ok(evnt);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Event>>> GetEvents() {
            var events = await _eventRepository.GetAll();
            return Ok(events);
        }

        [HttpPost]
        public async Task<ActionResult> CreateEvent(CreateEventDto createEventDto) {
            Event evnt = new()
            {
                Name = createEventDto.Name,
                Description = createEventDto.Description,
                Plan = createEventDto.Plan,
                Organizer = createEventDto.Organizer,
                Speaker = createEventDto.Speaker,
                EventTime = DateTime.Now,
                EventPlace = createEventDto.EventPlace
            };
    
            await _eventRepository.Add(evnt);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEvent(int id) {
            await _eventRepository.Delete(id);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProduct(int id, UpdateEventDto updateEventDto)
        {
            Event evnt = new()
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
    
            await _eventRepository.Update(evnt);
            return Ok();
        }
    }
}