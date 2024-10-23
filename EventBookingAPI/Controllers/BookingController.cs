using EventBookingAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EventBookingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BookingController(ApplicationDbContext context)
        {
            _context = context;
        }

        // POST: api/Booking
        [HttpPost]
        [Authorize(Roles = "Customer")]
        public async Task<ActionResult<Booking>> BookEvent(Booking booking)
        {
            var eventItem = await _context.Events.FindAsync(booking.EventId);
            if (eventItem == null || eventItem.TicketsAvailable < booking.Quantity)
            {
                return BadRequest("Insufficient tickets available.");
            }

            eventItem.TicketsAvailable -= booking.Quantity;
            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(BookEvent), new { id = booking.Id }, booking);
        }
    }

}
