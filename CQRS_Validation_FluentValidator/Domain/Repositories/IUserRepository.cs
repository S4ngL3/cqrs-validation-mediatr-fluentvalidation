using Contracts.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Contracts.Repositories
{
    public interface IUserRepository
    {
        Task<List<User>> GetAsync(CancellationToken cancellationToken = default);

        Task<User> GetByIdAsync(int userId, CancellationToken cancellationToken = default);

        void Insert(User user);
        void Update(User user);
        void Delete(User user);
    }
}
