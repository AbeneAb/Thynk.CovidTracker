namespace TestManagement.Application.Queries.TestCenter
{
    public class GetAllTestCenterListHandler : IRequestHandler<GetAllTestCenterListQuery,IEnumerable<TestCenterVM>>
    {
        private readonly ITestCenterRepository _testCenterRepository;
        private readonly ILogger<GetAllTestCenterListHandler> _logger;
        public GetAllTestCenterListHandler(ITestCenterRepository testCenterRepository,ILogger<GetAllTestCenterListHandler> logger)
        {
            _testCenterRepository = testCenterRepository;
            _logger = logger;
        }
        public async Task<IEnumerable<TestCenterVM>> Handle(GetAllTestCenterListQuery request, CancellationToken cancellationToken)
        {
            var data = await _testCenterRepository.GetAllTestCentersAsync();
            return data.Select(x => new TestCenterVM
            {
                Id = x.Id,
                AvailableFrom = x.AvailableFrom,
                Name = x.Name,
                AvailableSpace = x.TestCenterAvailableCapacity.AvailableSpace,
                AvailableUnitl = x.AvailableUntil,
                Capacity = x.Capacity,
                IsAvailable = x.IsAvailable,
                City = x.Address.City,
                State = x.Address.State,
                Street = x.Address.Street,
                ZipCode = x.Address.ZipCode,
            });
        }
    }
}
