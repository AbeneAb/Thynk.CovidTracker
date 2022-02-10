namespace TestManagement.Application.Commands.Booking
{
    public class CreateBookingCommandHandler : IRequestHandler<CreateBookingCommand, Guid>
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IUserRepository _userRepository;
        private readonly IAvailableCapacityRepository _availableCapacityRepository;
        public CreateBookingCommandHandler(IBookingRepository bookingRepository,IUserRepository userRepository,IAvailableCapacityRepository availableCapacityRepository)
        {
            _bookingRepository = bookingRepository;
            _userRepository = userRepository;
            _availableCapacityRepository = availableCapacityRepository;
        }
        public async Task<Guid> Handle(CreateBookingCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.FirstAsync(c => c.FirstName == "Jane");
            var booking = new Domain.Entities.Booking(request.TestCenter,user.Id, request.BookingDate);
            await _bookingRepository.AddAsync(booking);
            await _availableCapacityRepository.UpdateAvailablity(request.TestCenter, -1);
            await _bookingRepository.UnitOfWork.SaveChanges();
            return booking.Id;
        }
    }
}
