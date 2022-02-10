namespace TestManagement.Application.Commands.Booking
{
    public class CancelBookingCommand : IRequest<bool>
    {
        public CancelBookingCommand()
        {

        }
        public Guid Guid { get; set; }
        public CancelBookingCommand(Guid id)
        {
            Guid = id;
        }
    }
}
