namespace TestManagement.Application.Queries.TestCenter
{
    public class GetAvailableTestCenterQuery : IRequest<IEnumerable<TestCenterVM>>
    {
        public bool IsAvailable { get; set; }
        public GetAvailableTestCenterQuery(bool available)
        {
            IsAvailable = available;
        }
    }
}
