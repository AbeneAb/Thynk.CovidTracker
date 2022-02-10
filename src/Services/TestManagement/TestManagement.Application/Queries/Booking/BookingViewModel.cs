namespace TestManagement.Application.Queries.Booking;

public record BookingVM
{
    public Guid Id { get; set; }
    public string TestCenter { get; init; }
    public DateTime BookingDate { get; init; }
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public DateTime DOB { get; init; }
    public string BookingStatus { get; init; }
}


