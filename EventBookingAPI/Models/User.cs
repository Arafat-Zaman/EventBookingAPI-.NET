namespace EventBookingAPI.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Role { get; set; }  // E.g., "Organizer", "Customer"
        public List<Booking> Bookings { get; set; }
    }

}
