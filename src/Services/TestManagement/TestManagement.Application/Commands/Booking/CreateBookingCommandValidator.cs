namespace TestManagement.Application.Commands.Booking
{
    public class CreateBookingCommandValidator : AbstractValidator<CreateBookingCommand>
    {
        private readonly IAvailableCapacityRepository _availableCapacityRepository;
        public CreateBookingCommandValidator(IAvailableCapacityRepository availableCapacityRepository)
        {
            _availableCapacityRepository = availableCapacityRepository;
            RuleFor(b=>b.TestCenter).NotEmpty().NotNull();
            RuleFor(b=>b.BookingDate).NotEmpty().NotNull().Must(ValidBookingDate)
                .WithMessage("Please specify valid data");
            RuleFor(b=>b.BookingStatus).NotEmpty().NotNull().GreaterThan(-1);
            RuleFor(b => b.TestCenter)
                .MustAsync(async (entity, value, c) => await IsSpaceAvailable(entity))
                .WithMessage("No space available for this test center");
        }
        private bool ValidBookingDate(DateTime dateTime) 
        {
            return dateTime >= DateTime.UtcNow;
        }
        private async Task<bool> IsSpaceAvailable(CreateBookingCommand createBookingCommand) 
        {
            var data = await _availableCapacityRepository.FirstAsync(x => x.TestCenterId == createBookingCommand.TestCenter);
            if(data != null && data.AvailableSpace > 0)
                return true;
            return false;
        }
    }
}
