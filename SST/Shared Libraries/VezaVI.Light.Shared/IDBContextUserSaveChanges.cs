using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace VezaVI.Light.Shared
{
    public interface IDBContextUserSaveChanges
    {
        Task<int> SaveChangesAsync(Guid? userID, CancellationToken cancellationToken = default);
    }
}
