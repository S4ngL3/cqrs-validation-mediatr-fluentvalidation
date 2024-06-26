﻿using System.Threading;
using System.Threading.Tasks;

namespace Contracts.Repositories
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
