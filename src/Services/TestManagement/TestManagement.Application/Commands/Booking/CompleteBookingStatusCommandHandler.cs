namespace TestManagement.Application.Commands.Booking
{
    public class CompleteBookingStatusCommandHandler : IRequestHandler<CompleteBookingCommand, bool>
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IAvailableCapacityRepository _availableCapacityRepository;
        public CompleteBookingStatusCommandHandler(IBookingRepository bookingRepository,IAvailableCapacityRepository availableCapacityRepository)
        {
            _bookingRepository = bookingRepository;
            _availableCapacityRepository = availableCapacityRepository;
        }
        public async Task<bool> Handle(CompleteBookingCommand request, CancellationToken cancellationToken)
        {
            var data = await _bookingRepository.GetByIdAsync(request.Guid);
            if (data == null)
                return false;
            data.SetBookingStatusToCompleted();
            await _availableCapacityRepository.UpdateAvailablity(data.TestCenterId, 1);
            await _bookingRepository.UnitOfWork.SaveChanges();
            return true;
        }
    }
}
