namespace TestManagement.Application.Commands.Result
{
    public class CreateResultCommandValidator : AbstractValidator<CreateResultCommand>
    {
        private readonly ISpecimenInformationRepository _specimenInformationRepository;
        public CreateResultCommandValidator(ISpecimenInformationRepository specimenInformationRepository)
        {
            _specimenInformationRepository = specimenInformationRepository;
            RuleFor(c=>c.BookingId).NotEmpty().NotNull();
            RuleFor(c=>c.ResultIssuedDate).NotEmpty().NotNull().GreaterThan(DateTime.UtcNow);
            RuleFor(c=>c.SpecimenId).MustAsync(async (entity, value, c) => await NoSpecimenForGivenBooking(entity))
                .WithMessage("There should be one specimen for result");
        }
        private async Task<bool> NoSpecimenForGivenBooking(CreateResultCommand bookingGuid)
        {
            var data = await _specimenInformationRepository.GetAsync(x => x.BookingId == bookingGuid.BookingId);
            if (data == null)
                return false;
            return true;
        }
    }
}
