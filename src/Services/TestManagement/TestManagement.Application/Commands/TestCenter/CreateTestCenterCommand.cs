namespace TestManagement.Application.Commands.TestCenter
{
    [DataContract]
    public class CreateTestCenterCommand : IRequest<Guid>
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public uint Capacity { get;  set; }
        public DateTime AvailableFrom { get;  set; }
        public DateTime AvailableUntil { get;  set; }
        public bool IsAvailable { get;  set; }
        public string City { get;  set; }
        public string State { get;  set; }
        public string Street { get;  set; }
        public string ZipCode { get;  set; }
        public uint AvailableSpace { get;  set; }
    }
}
