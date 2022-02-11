namespace TestManagement.Domain.QueryModel
{
    public class TestCenterBookingReport
    {
        public Guid Id { get; set; }
        public uint Capacity { get; set; }
        public string Name { get; set; }
        public int? TotalBooking { get; set; }
        public int? TotalPending { get; set; }
        public int? TotalNegative { get; set; }
        public int? TotalPositive { get; set; }
    }
}
