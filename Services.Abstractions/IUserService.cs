using Contracts.Dtos.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstractions
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<UserDto> GetUserByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<UserDto> CreateUserAsync(UserForCreateDto userForCreateDto, CancellationToken cancellationToken = default);
        Task<UserDto> UpdateUserAsync(int id, UserForUpdateDto userForUpdateDto, CancellationToken cancellationToken = default);
    }
}
