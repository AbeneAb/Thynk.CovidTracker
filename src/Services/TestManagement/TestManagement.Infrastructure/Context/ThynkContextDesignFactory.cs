using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestManagement.Infrastructure.Context
{
    public class ThynkContextDesignFactory : IDesignTimeDbContextFactory<ThynkContext>
    {
        public ThynkContext CreateDbContext(string[] args)
        {
            var builderOptions = new DbContextOptionsBuilder<ThynkContext>().
                UseSqlServer("Server=localhost,5433;Initial Catalog=thynkdb;User Id=sa;Password=Thynk1234;");
            return new ThynkContext(builderOptions.Options, new NoMediator());
        }

        class NoMediator : IMediator
        {
            public IAsyncEnumerable<TResponse> CreateStream<TResponse>(IStreamRequest<TResponse> request, CancellationToken cancellationToken = default)
            {
                throw new NotImplementedException();
            }

            public IAsyncEnumerable<object?> CreateStream(object request, CancellationToken cancellationToken = default)
            {
                throw new NotImplementedException();
            }

            public Task Publish<TNotification>(TNotification notification, CancellationToken cancellationToken = default(CancellationToken)) where TNotification : INotification
            {
                return Task.CompletedTask;
            }

            public Task Publish(object notification, CancellationToken cancellationToken = default)
            {
                return Task.CompletedTask;
            }

            public Task<TResponse> Send<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default(CancellationToken))
            {
                return Task.FromResult<TResponse>(default(TResponse));
            }

            public Task<object> Send(object request, CancellationToken cancellationToken = default)
            {
                return Task.FromResult(default(object));
            }
        }
    }
}
