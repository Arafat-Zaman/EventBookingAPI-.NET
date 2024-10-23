namespace EventBookingAPI.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public decimal Price { get; set; }
        public int TicketsAvailable { get; set; }
        public List<Booking> Bookings { get; set; }
    }

}
