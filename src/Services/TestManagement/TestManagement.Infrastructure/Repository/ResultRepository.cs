namespace TestManagement.Infrastructure.Repository
{
    public class ResultRepository : AsyncRepository<Result>, IResultRepository
    {
        public ResultRepository(ThynkContext thynkContext) : base(thynkContext)
        {

        }
    }
}
