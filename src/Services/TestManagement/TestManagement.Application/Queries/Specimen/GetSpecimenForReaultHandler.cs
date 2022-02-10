namespace TestManagement.Application.Queries.Specimen
{
    public class GetSpecimenForReaultHandler : IRequestHandler<GetSpecimenForResult, IEnumerable<SpecimenVM>>
    {
        private readonly ISpecimenInformationRepository _specimenInformationRepository;
        public GetSpecimenForReaultHandler(ISpecimenInformationRepository specimenInformationRepository)
        {
            _specimenInformationRepository = specimenInformationRepository;
        }
        public async Task<IEnumerable<SpecimenVM>> Handle(GetSpecimenForResult request, CancellationToken cancellationToken)
        {
            var data = await _specimenInformationRepository.GetAllSpecimensInprogressAsync();
            return data.Select(x => new SpecimenVM {
                BookingDate = x.Booking.BookDate,
                BookingId = x.BookingId,
                FirstName = x.Booking.User.FirstName,
                LastName = x.Booking.User.LastName,
                SpecimenCollectionDate = x.CollectionDate,
                SpecimenId = x.Id,
                SpecimenType = x.SpecimenTypes.Name
            });
        }
    }
}
