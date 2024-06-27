using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Contracts.Entities;

namespace Contracts.Repositories
{
    public interface IUserRepository
    {
        Task<List<User>> GetAsync(CancellationToken cancellationToken = default);

        Task<User> GetByIdAsync(int userId, CancellationToken cancellationToken = default);

        void Insert(User user);
    }
}
