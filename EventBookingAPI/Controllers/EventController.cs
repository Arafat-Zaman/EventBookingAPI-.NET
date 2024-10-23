using EventBookingAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EventBookingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EventController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Event
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Event>>> GetEvents()
        {
            return await _context.Events.ToListAsync();
        }

        // POST: api/Event
        [HttpPost]
        [Authorize(Roles = "Organizer")]
        public async Task<ActionResult<Event>> PostEvent(Event eventItem)
        {
            _context.Events.Add(eventItem);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetEvents), new { id = eventItem.Id }, eventItem);
        }
    }

}
