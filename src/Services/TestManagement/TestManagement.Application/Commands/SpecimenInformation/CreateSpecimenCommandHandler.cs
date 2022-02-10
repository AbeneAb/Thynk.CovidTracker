namespace TestManagement.Application.Commands.SpecimenInformation
{
    public class CreateSpecimenCommandHandler : IRequestHandler<CreateSpecimenCommand, Guid>
    {
        private readonly ISpecimenInformationRepository _specimenInformationRepository;
        private readonly IResultRepository _resultRepository;
        public CreateSpecimenCommandHandler(ISpecimenInformationRepository specimenInformationRepository,IResultRepository resultRepository)
        {
            _specimenInformationRepository = specimenInformationRepository;
            _resultRepository = resultRepository;
        }
        public async Task<Guid> Handle(CreateSpecimenCommand request, CancellationToken cancellationToken)
        {
            var specimen = new Domain.Entities.SpecimenInformation(request.BookingId,request.CollectionDate,request.SpecimenTypeId);
            await _specimenInformationRepository.AddAsync(specimen);
            var result = new Domain.Entities.Result(request.BookingId, DateTime.Now, specimen.Id);
            await _resultRepository.AddAsync(result);
            await _specimenInformationRepository.UnitOfWork.SaveChanges();
            return specimen.Id;
        }
    }
}
