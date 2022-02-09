using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestManagement.Domain.Common
{
    public interface IUnitOfWork : IDisposable
    {
        bool IsInTransaction { get; }
        Task<Guid> SaveChangesAsync(CancellationToken cancellation = default(CancellationToken));
        Task<bool> SaveEntitiesAsync(CancellationToken cancellation = default(CancellationToken));

    }
}
