namespace TestManagement.Domain.Interfaces
{
    public interface IResultRepository : IAsyncRepository<Result>
    {
        Task<IEnumerable<Result>> GetResultsAsync();
    }
}
