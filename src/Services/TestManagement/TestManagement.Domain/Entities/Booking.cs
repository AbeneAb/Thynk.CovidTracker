namespace TestManagement.Domain.Entities
{
    public class Booking : EntityBase
    {
        public Guid TestCenterId { get; set; }
        public Guid UserId { get; set; } 
        public  DateTime BookDate { get; set; }
        public BookingStatus BookingStatus { get; private set; } = BookingStatus.Reserved;
        public virtual TestCenter TestCenter { get; set; }
        public Booking(Guid testCenter,Guid userId,DateTime bookDate, string bookingStatus):base()
        {
            TestCenterId = testCenter;
            UserId = userId;
            BookDate = bookDate;
            BookingStatus = Enumeration.FromDispalyName<BookingStatus>(bookingStatus);
        }

    }
}
