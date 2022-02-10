namespace TestManagement.Domain.Interfaces
{
    public interface IAvailableCapacityRepository : IAsyncRepository<TestCenterAvailableCapacity>
    {
        Task UpdateAvailablity(Guid testCenterId,int value);
    }
}
