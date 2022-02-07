namespace TestManagement.Domain.Entities
{
    public class TestCenterAvailableCapacity : EntityBase
    {
        public Guid TestCenterId { get; set; }
        public uint AvailableSpace { get; set; }
        public TestCenter TestCenter { get; set; }
        public TestCenterAvailableCapacity()
        {

        }
        public TestCenterAvailableCapacity(Guid testCenterId, uint availableApace) : base()
        {
            TestCenterId = testCenterId;
            AvailableSpace = availableApace;
        }
    }
}
