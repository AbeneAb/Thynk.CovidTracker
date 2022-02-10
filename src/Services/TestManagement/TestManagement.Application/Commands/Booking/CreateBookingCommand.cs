namespace TestManagement.Application.Commands.Booking
{
    public class CreateBookingCommand : IRequest<Guid>
    {
        public Guid TestCenter { get; set; }
        public DateTime BookingDate { get; set; }
        public int BookingStatus { get; set; }
    }
}
