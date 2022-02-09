namespace TestManagement.Infrastructure.Repository
{
    public class TestCenterLogRepository : AsyncRepository<TestCenterLog>, ITestCenterLogRepository
    {
        public TestCenterLogRepository(ThynkContext thynkContext) : base(thynkContext)
        {

        }
    }
}
