namespace TestManagement.Application.Commands.SpecimenInformation
{
    public class CreateSpecimenCommadValidator : AbstractValidator<CreateSpecimenCommand>
    {
        private readonly ISpecimenInformationRepository _specimenInformationRepository;
        public CreateSpecimenCommadValidator(ISpecimenInformationRepository specimenInformationRepository)
        {
            _specimenInformationRepository = specimenInformationRepository;
            RuleFor(c => c.BookingId)
                .NotEmpty().NotNull()
                .MustAsync(async (entity, value, c) => await NoSpecimenForGivenBooking(entity))
                .WithMessage("There should only be one specimen for booking");
            RuleFor(s => s.CollectionDate).NotNull().NotEmpty().GreaterThan(DateTime.UtcNow);

        }
        private async Task<bool> NoSpecimenForGivenBooking(CreateSpecimenCommand bookingGuid) 
        {
            var data = await _specimenInformationRepository.GetAsync(x => x.BookingId == bookingGuid.BookingId);
            if (data == null || data.Count() == 0)
                return true;
            return false;
        }
    }
}
