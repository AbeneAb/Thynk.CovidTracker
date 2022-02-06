namespace TestManagement.Domain.Entities
{
    public class TestCenterLog : EntityBase
    {
        public Guid BookingId { get; set; }
        public Guid UserId { get; set; }
        public int BookedValue { get; set; }
        public int AvailablBefore { get; set; }
        public int AvailableAfter { get; set; } 
        public TestCenterLog(Guid bookingId,Guid userId,int bookedValue,int availableBefore):base()
        {
            BookingId = bookingId;
            UserId = userId;
            BookedValue = bookedValue;
            AvailablBefore = availableBefore;
        }

    }
}
