namespace TestManagement.Domain.Interfaces
{
    public interface IBookingRepository : IAsyncRepository<Booking>
    {
        Task<IEnumerable<Booking>> GetAllBookings();

    }
}
