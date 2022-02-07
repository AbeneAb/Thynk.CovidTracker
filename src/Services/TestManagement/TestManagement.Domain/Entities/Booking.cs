namespace TestManagement.Domain.Entities
{
    public class Booking : EntityBase
    {
        public Guid TestCenterId { get; set; }
        public Guid UserId { get; set; } 
        public  DateTime BookDate { get; set; }
        private int _bookingStatus;
        public BookingStatus BookingStatus { get; private set; } = BookingStatus.Reserved;
        public virtual TestCenter TestCenter { get; set; }      
        public virtual User User { get; set; } 
        public virtual SpecimenInformation SpecimenInformation { get; set; }
        public virtual Result Result { get; set; }
        public TestCenterLog TestCenterLog { get; set; }
        public Booking()
        {

        }
        public Booking(Guid testCenter,Guid userId,DateTime bookDate):base()
        {
            TestCenterId = testCenter;
            UserId = userId;
            BookDate = bookDate;
            _bookingStatus = BookingStatus.Reserved.Id;
        }

    }
}
