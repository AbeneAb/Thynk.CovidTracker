namespace TestManagement.Application.Queries.Booking
{
    public class GetBookingWithSpecimenQueryHandler : IRequestHandler<GetBookingWithSpecimenQuery,IEnumerable<BookingVM>>
    {
        private readonly IBookingRepository _bookingRepository;
        public GetBookingWithSpecimenQueryHandler(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        public async Task<IEnumerable<BookingVM>> Handle(GetBookingWithSpecimenQuery request, CancellationToken cancellationToken)
        {
            var booking = (await _bookingRepository.GetBookingWithSpecimen());
            return booking.Select(b => new BookingVM {
                BookingDate = b.BookDate,
                FirstName = b.User.FirstName,
                LastName = b.User.LastName,
                Id = b.Id,
                DOB = b.BookDate }

            );
        }
    }
}
