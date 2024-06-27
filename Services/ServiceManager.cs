using Contracts.Repositories;
using Services.Abstractions;

namespace Services
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<IUserService> _lazyUserService;

        public ServiceManager(IRepositoryManager repository)
        {
            _lazyUserService = new Lazy<IUserService>(() => new UserService(repository));
        }

        public IUserService UserService => _lazyUserService.Value;
    }
}
