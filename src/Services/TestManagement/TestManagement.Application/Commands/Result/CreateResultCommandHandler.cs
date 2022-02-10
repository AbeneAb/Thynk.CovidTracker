namespace TestManagement.Application.Commands.Result
{
    public class CreateResultCommandHandler : IRequestHandler<CreateResultCommand, Guid>
    {
        private readonly IResultRepository _resultRepository;
        public CreateResultCommandHandler(IResultRepository resultRepository)
        {
            _resultRepository = resultRepository;
        }
        public async Task<Guid> Handle(CreateResultCommand request, CancellationToken cancellationToken)
        {
            var result = new Domain.Entities.Result(request.BookingId,request.ResultIssuedDate,request.SpecimenId);
            await _resultRepository.AddAsync(result);
            await _resultRepository.UnitOfWork.SaveChanges();
            return result.Id;

        }
    }
}
