namespace TestManagement.Infrastructure.Repository
{
    public class AvailableCapacityRepository : AsyncRepository<TestCenterAvailableCapacity>,IAvailableCapacityRepository
    {
        public AvailableCapacityRepository(ThynkContext thynkContext) : base(thynkContext)
        {

        }
    }
}
