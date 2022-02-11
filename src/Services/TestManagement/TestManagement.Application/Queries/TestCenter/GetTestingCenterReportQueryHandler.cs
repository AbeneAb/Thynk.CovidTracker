namespace TestManagement.Application.Queries.TestCenter
{
    public class GetTestingCenterReportQueryHandler : IRequestHandler<GetTestingCenterReportQuery, IEnumerable<TestCenterBookingReport>>
    {
        private ITestCenterRepository _testCenterRepository;
        public GetTestingCenterReportQueryHandler(ITestCenterRepository testCenterRepository)
        {
            _testCenterRepository = testCenterRepository;
        }
        public async Task<IEnumerable<TestCenterBookingReport>> Handle(GetTestingCenterReportQuery request, CancellationToken cancellationToken)
        {
            var data = _testCenterRepository.GetTestCenterReport();
            return await data;
        }
    }
}
