namespace TestManagement.Domain.Entities
{
    public class TestCenterAvailableCapacity : EntityBase
    {
        public Guid TestCenterId { get; set; }
        public uint AvailabeSpace { get; set; }
        public TestCenterAvailableCapacity(Guid testCenterId, uint availableApace) : base()
        {
            TestCenterId = testCenterId;
            AvailabeSpace = availableApace;
        }
    }
}
