namespace TestManagement.Application.Commands.Booking
{
    public class CancelBookingCommandHandler : IRequestHandler<CancelBookingCommand, bool>
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IAvailableCapacityRepository _availableCapacityRepository;
        public CancelBookingCommandHandler(IBookingRepository bookingRepository,IAvailableCapacityRepository availableCapacityRepository)
        {
            _bookingRepository = bookingRepository;
            _availableCapacityRepository = availableCapacityRepository;
        }
        public async Task<bool> Handle(CancelBookingCommand request, CancellationToken cancellationToken)
        {
            var data = await _bookingRepository.GetByIdAsync(request.Guid);
            if(data == null)
                return false;
            data.SetStatusToCanceled();
            await _availableCapacityRepository.UpdateAvailablity(data.TestCenterId, 1);
            await _bookingRepository.UnitOfWork.SaveChanges();
            return true;
        }
    }
}
