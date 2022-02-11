namespace TestManagement.Application.Queries.TestCenter
{
    public class GetTestingCenterReportQueryHandler : IRequestHandler<GetTestingCenterReportQuery, IEnumerable<TestBookingReport>>
    {
        private ITestCenterRepository _testCenterRepository;
        public GetTestingCenterReportQueryHandler(ITestCenterRepository testCenterRepository)
        {
            _testCenterRepository = testCenterRepository;
        }
        public async Task<IEnumerable<TestBookingReport>> Handle(GetTestingCenterReportQuery request, CancellationToken cancellationToken)
        {
            var data = _testCenterRepository.GetTestCenterReport();
            return null;
        }
    }
}
