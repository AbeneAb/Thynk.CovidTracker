namespace TestManagement.Application.Commands.Result
{
    public class CreateResultCommandHandler : IRequestHandler<CreateResultCommand, Guid>
    {
        private readonly IResultRepository _resultRepository;
        private readonly ISpecimenInformationRepository _specimenInformationRepository;
        public CreateResultCommandHandler(IResultRepository resultRepository,ISpecimenInformationRepository specimenInformationRepository)
        {
            _resultRepository = resultRepository;
            _specimenInformationRepository = specimenInformationRepository;
        }
        public async Task<Guid> Handle(CreateResultCommand request, CancellationToken cancellationToken)
        {
            var specimen = await _specimenInformationRepository.FirstAsync(s => s.BookingId == request.BookingId);
            var result = new Domain.Entities.Result(request.BookingId,request.ResultIssuedDate, specimen.Id);
            await _resultRepository.AddAsync(result);
            await _resultRepository.UnitOfWork.SaveChanges();
            return result.Id;

        }
    }
}
