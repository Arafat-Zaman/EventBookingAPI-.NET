namespace EventBookingAPI.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public int BookingId { get; set; }
        public Booking Booking { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentStatus { get; set; }
    }

}
