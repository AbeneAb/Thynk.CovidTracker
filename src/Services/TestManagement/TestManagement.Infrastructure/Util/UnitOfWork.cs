namespace TestManagement.Infrastructure.Util
{
    public class UnitOfWork : IUnitOfWork
    {
        private IDbContextTransaction _transaction;
        private DbContext _dbContext;
        public UnitOfWork(DbContext context)
        {
            _dbContext = context;
        }
        public bool IsInTransaction => _transaction != null;

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<Guid> SaveChangesAsync(CancellationToken cancellation = default)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveEntitiesAsync(CancellationToken cancellation = default)
        {
            throw new NotImplementedException();
        }
    }
}
