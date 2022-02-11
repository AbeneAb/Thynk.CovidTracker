namespace TestManagement.Infrastructure.Repository
{
    public class BookingRepository : AsyncRepository<Booking>, IBookingRepository
    {
        private readonly ThynkContext _context;
        public BookingRepository(ThynkContext thynkContext) : base(thynkContext)
        {
            _context = thynkContext;
        }

        public async Task<IEnumerable<Booking>> GetAllBookings()
        {
            var data = _context.Bookings
                .Include(b=>b.User)
                .Include(b=>b.TestCenter)
                .Include(b=>b.BookingStatus).AsNoTracking().ToListAsync();
            return await data;
        }

        public async Task<IEnumerable<Booking>> GetBookingWithSpecimen()
        {
            var data = _context.Bookings
                .Include(B => B.SpecimenInformation)
                .Include(b=>b.User).Include(b=>b.Result).Where(b=>b.Result != null).AsNoTracking().ToListAsync();
            return await data;
        }
    }
}
