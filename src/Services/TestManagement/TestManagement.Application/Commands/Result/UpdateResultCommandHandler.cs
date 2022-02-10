using TestManagement.Domain.Enumerations;

namespace TestManagement.Application.Commands.Result
{
    public class UpdateResultCommandHandler : IRequestHandler<UpdateResultCommand>
    {
        private readonly IResultRepository _repository;
        public UpdateResultCommandHandler(IResultRepository resultRepository)
        {
            _repository = resultRepository;
        }
        public async Task<Unit> Handle(UpdateResultCommand request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetByIdAsync(request.Id);
            var status = ResultStatus.From(request.Result);
            result.SetResultStatus(status.Id);
            await _repository.UpdateAsync(result);
            await _repository.UnitOfWork.SaveChanges();
            return Unit.Value;
        }
    }
}
