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
    }
}
