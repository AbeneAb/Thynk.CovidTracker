namespace TestManagement.Application.Commands.Booking
{
    public class CompleteBookingCommand : IRequest<bool>
    {
        public Guid Guid { get; set; }
        public CompleteBookingCommand(Guid id)
        {
            Guid = id;  
        }
    }
}
