namespace TestManagement.Infrastructure.Repository
{
    public class ResultRepository : AsyncRepository<Result>, IResultRepository
    {
        private readonly ThynkContext _context;
        public ResultRepository(ThynkContext thynkContext) : base(thynkContext)
        {
            _context = thynkContext;
        }

        public async Task<IEnumerable<Result>> GetResultsAsync()
        {
            var data = await _context.Results.Include(r => r.Status)
                .Include(b => b.Booking).ThenInclude(b => b.TestCenter)
                .Include(b => b.Booking)
                .ThenInclude(u => u.User).AsNoTracking().ToListAsync();
            return data;

        }
    }
}
