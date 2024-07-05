using Contracts.Repositories;
using System;

namespace Persistence.Repositories
{
    public sealed class RepositoryManager : IRepositoryManager
    {
        private readonly Lazy<IUserRepository> _lazyUserRepository;
        private readonly Lazy<IUnitOfWork> _lazyUnitOfWork;

        public RepositoryManager(ApplicationDbContext context)
        {
            _lazyUserRepository = new Lazy<IUserRepository>(() => new UserRepository(context));
            _lazyUnitOfWork = new Lazy<IUnitOfWork>(() => new UnitOfWork(context));
        }

        public IUserRepository UserRepository => _lazyUserRepository.Value;
        public IUnitOfWork UnitOfWork => _lazyUnitOfWork.Value;
    }
}
