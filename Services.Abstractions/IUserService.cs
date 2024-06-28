using Contracts.Dtos.Users;

namespace Services.Abstractions
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<UserDto> GetUserByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<UserDto> CreateUserAsync(UserForCreateDto userForCreateDto, CancellationToken cancellationToken = default);
        Task UpdateUserAsync(int id, UserForUpdateDto userForUpdateDto, CancellationToken cancellationToken = default);
        Task DeleteAsync(int id, CancellationToken cancellationToken = default);
    }
}
