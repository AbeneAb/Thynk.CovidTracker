namespace TestManagement.Infrastructure.Repository
{
    public class TestCenterRepository : AsyncRepository<TestCenter>, ITestCenterRepository
    {
        private readonly ThynkContext _context;
        public TestCenterRepository(ThynkContext thynkContext) : base(thynkContext)
        {
            _context = thynkContext;
        }

        public async Task<IEnumerable<TestCenter>> GetAllTestCentersAsync()
        {
            var data = _context.Tests.Include(t=>t.Address)
                .Include(t=>t.TestCenterAvailableCapacity).AsNoTracking().ToListAsync();
            return await data;
        }

        public async Task<IEnumerable<TestCenter>> GetAvailabletestCenters(bool available)
        {
            var data = _context.Tests.Include(t => t.Address)
               .Include(t => t.TestCenterAvailableCapacity)
               .Where(x => x.IsAvailable == available
               && x.AvailableUntil > DateTime.Now
               && x.TestCenterAvailableCapacity.AvailableSpace > 0)
               .AsNoTracking().ToListAsync();
            return await data;
        }

        public Task<IEnumerable<TestCenter>> GetTestCenterReport()
        {
            throw new NotImplementedException();
        }
    }
}
