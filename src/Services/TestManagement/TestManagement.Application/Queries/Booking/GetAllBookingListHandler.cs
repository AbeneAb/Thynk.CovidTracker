using TestManagement.Domain.Enumerations;

namespace TestManagement.Application.Queries.Booking
{
    public class GetAllBookingListHandler : IRequestHandler<GetAllBookingListQuery, IEnumerable<BookingVM>>
    {
        private readonly IBookingRepository _bookingRepository;
        public GetAllBookingListHandler(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }
        public async Task<IEnumerable<BookingVM>> Handle(GetAllBookingListQuery request, CancellationToken cancellationToken)
        {
            var data = await _bookingRepository.GetAllBookings();
            return data.Select(b => new BookingVM()
            {
                Id= b.Id,
                BookingDate = b.BookDate,
                BookingStatus = b.BookingStatus.Name,
                FirstName = b.User.FirstName,
                LastName = b.User.LastName,
                TestCenter = b.TestCenter.Name
            });
        }
    }
}
