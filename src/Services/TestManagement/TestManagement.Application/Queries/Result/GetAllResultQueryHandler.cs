using TestManagement.Domain.Enumerations;

namespace TestManagement.Application.Queries.Result
{
    public class GetAllResultQueryHandler : IRequestHandler<GetAllResultQuery, IEnumerable<ResultVM>>
    {
        public IResultRepository _resultRepository;
        public GetAllResultQueryHandler(IResultRepository resultRepository)
        {
            _resultRepository = resultRepository;
        }
        public async Task<IEnumerable<ResultVM>> Handle(GetAllResultQuery request, CancellationToken cancellationToken)
        {
            var data = await _resultRepository.GetResultsAsync();
            return data.Select(x => new ResultVM
            {
                FirstName = x.Booking.User.FirstName,
                Id = x.Id,
                LastName = x.Booking.User.LastName,
                Result = x.Status.Name
            });
        }
    }
}
