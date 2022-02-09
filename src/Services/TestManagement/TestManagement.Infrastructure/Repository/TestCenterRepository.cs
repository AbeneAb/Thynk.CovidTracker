namespace TestManagement.Infrastructure.Repository
{
    public class TestCenterRepository : AsyncRepository<TestCenter>, ITestCenterRepository
    {
        public TestCenterRepository(ThynkContext thynkContext) : base(thynkContext)
        {

        }
    }
}
