namespace TestManagement.Infrastructure.Repository
{
    public class BookingRepository : AsyncRepository<Booking>, IBookingRepository
    {
        public BookingRepository(ThynkContext thynkContext):base(thynkContext)
        {

        }
    }
}
