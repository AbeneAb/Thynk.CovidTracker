namespace TestManagement.Application.Queries.Booking
{
    public class GetBookingWithSpecimenQueryHandler : IRequestHandler<GetBookingWithSpecimenQuery,IEnumerable<BookingResultVM>>
    {
        private readonly IBookingRepository _bookingRepository;
        public GetBookingWithSpecimenQueryHandler(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        public async Task<IEnumerable<BookingResultVM>> Handle(GetBookingWithSpecimenQuery request, CancellationToken cancellationToken)
        {
            var booking = (await _bookingRepository.GetBookingWithSpecimen());
            return booking.Select(b => new BookingResultVM
            {
                BookingDate = b.BookDate,
                FirstName = b.User.FirstName,
                LastName = b.User.LastName,
                Id = b.Id,
                DOB = b.BookDate,
                ResultId = b.Result.Id
            }

            );
        }
    }
}
