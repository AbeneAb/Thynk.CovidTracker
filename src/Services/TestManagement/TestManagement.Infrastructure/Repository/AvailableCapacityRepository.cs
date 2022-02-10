namespace TestManagement.Infrastructure.Repository
{
    public class AvailableCapacityRepository : AsyncRepository<TestCenterAvailableCapacity>,IAvailableCapacityRepository
    {
        public AvailableCapacityRepository(ThynkContext thynkContext) : base(thynkContext)
        {

        }

        public async Task UpdateAvailablity(Guid id, int value)
        {
            var availableCapacity = await FirstAsync(c=>c.TestCenterId == id);
            if (value < 0)
                availableCapacity.AvailableSpace -= 1;
            else
                availableCapacity.AvailableSpace += 1;
            await UpdateAsync(availableCapacity);
        }
    }
}
