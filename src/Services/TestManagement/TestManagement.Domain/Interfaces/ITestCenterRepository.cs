namespace TestManagement.Domain.Interfaces
{
    public interface ITestCenterRepository : IAsyncRepository<TestCenter>
    {
        Task<IEnumerable<TestCenter>> GetAllTestCentersAsync();
        Task<IEnumerable<TestCenter>> GetAvailabletestCenters(bool available);
        Task<IEnumerable<Domain.QueryModel.TestCenterBookingReport>> GetTestCenterReport();
    }
}
