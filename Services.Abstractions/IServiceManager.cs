using Services.Abstractions;

namespace Services
{
    public interface IServiceManager
    {
        IUserService UserService { get; }
    }
}
