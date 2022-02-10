namespace TestManagement.Application.Commands.TestCenter
{
    public class CreateTestCenterCommandHandler : IRequestHandler<CreateTestCenterCommand, Guid>
    {
        private readonly ITestCenterRepository _testCenterRepository;
        private readonly ILogger<CreateTestCenterCommandHandler> _logger;
        public CreateTestCenterCommandHandler(ITestCenterRepository testCenterRepository,ILogger<CreateTestCenterCommandHandler> logger)
        {
            _testCenterRepository = testCenterRepository;
            _logger = logger;
        }
        public async Task<Guid> Handle(CreateTestCenterCommand request, CancellationToken cancellationToken)
        {
            var address = new TestCenterAddress(request.City, request.State, request.Street, request.ZipCode);
            var testCenter = new Domain.Entities.TestCenter(request.Name,request.Capacity,request.AvailableFrom,request.AvailableUntil,request.IsAvailable,address); 
            if(request.AvailableSpace > 0)
            {
                testCenter.AddTestCenterAvailableSpace(request.AvailableSpace);
            }
            _logger.LogInformation("----Creating Test Center---{@testCenter}----", testCenter);
            await _testCenterRepository.AddAsync(testCenter);
            await _testCenterRepository.UnitOfWork.SaveChanges();
            return testCenter.Id;
        }
    }
}
