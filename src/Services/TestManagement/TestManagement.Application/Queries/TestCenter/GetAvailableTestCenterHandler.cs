namespace TestManagement.Application.Queries.TestCenter
{
    public class GetAvailableTestCenterHandler : IRequestHandler<GetAvailableTestCenterQuery, IEnumerable<TestCenterVM>>
    {
        private readonly ITestCenterRepository _testCenterRepository;
        public GetAvailableTestCenterHandler(ITestCenterRepository testCenterRepository)
        {
            _testCenterRepository = testCenterRepository;
        }
        public async Task<IEnumerable<TestCenterVM>> Handle(GetAvailableTestCenterQuery request, CancellationToken cancellationToken)
        {
            var data = await _testCenterRepository.GetAvailabletestCenters(request.IsAvailable);
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
