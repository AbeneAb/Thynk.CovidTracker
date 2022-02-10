using TestManagement.Domain.Interfaces;

namespace TestManagement.Infrastructure.Repository
{
    public class SpecimenInformationRepository : AsyncRepository<SpecimenInformation>, ISpecimenInformationRepository
    {
        private readonly ThynkContext _context;
        public SpecimenInformationRepository(ThynkContext thynkContext) : base(thynkContext)
        {
            _context = thynkContext;
        }

        public async Task<IEnumerable<SpecimenInformation>> GetAllSpecimensInprogressAsync()
        {
            var data = await _context.Specimens.Include(x=>x.Booking)
                .ThenInclude(b=>b.BookingStatus)
                .Include(b=>b.Booking).ThenInclude(u=>u.User)
                .Include(s=>s.SpecimenTypes)
                .Where(b=>b.Booking.BookingStatus == BookingStatus.InProgress)
                .AsSplitQuery().AsNoTracking().ToListAsync();
            return data;
        }
    }
}
