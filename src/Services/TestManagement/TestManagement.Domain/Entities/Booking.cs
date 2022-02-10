using System.Text.Json.Serialization;

namespace TestManagement.Domain.Entities
{
    public class Booking : EntityBase
    {
        public Guid TestCenterId { get; set; }
        public Guid UserId { get; set; } 
        public  DateTime BookDate { get; set; }
        private int _bookingStatus;
        public BookingStatus BookingStatus { get; private set; }
        public virtual TestCenter TestCenter { get; set; } 
        [JsonIgnore]
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
        public void SetStatusToCanceled() 
        {
            _bookingStatus = BookingStatus.Canceled.Id;
        }
        public void SetBookingStatusToCompleted() 
        {
            _bookingStatus = BookingStatus.Completed.Id;
        }

    }
}
