namespace TestManagement.Domain.Entities
{
    public class TestCenter : EntityBase
    {
        public string Name { get; protected set; }
        public uint Capacity { get; protected set; }
        public DateTime AvailableFrom { get; protected set; }
        public DateTime AvailableUntil { get; protected set; }
        public bool IsAvailable { get; protected set; }
        public TestCenterAddress Address { get; set; }
        public TestCenterAvailableCapacity TestCenterAvailableCapacity { get; protected set; }
        public virtual ICollection<TestCenterLog> TestCenterLogs { get; protected set; }
        public virtual ICollection<Booking> Bookings { get; protected set; }
        public TestCenter()
        {
            TestCenterLogs = new List<TestCenterLog>();
            Bookings = new List<Booking>();
        }
        public TestCenter(string name, uint capacity,DateTime availableFrom, DateTime availableUntil,bool isAvailable, TestCenterAddress address) : base()
        {
            Name = name;
            Capacity = capacity;
            Address = address;
            AvailableFrom = availableFrom;
            AvailableUntil = availableUntil;
            IsAvailable = isAvailable;
        }
    }
}
