using Contracts.Dtos.Users;
using Contracts.Entities;
using Contracts.Repositories;
using Mapster;
using Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public sealed class UserService : IUserService
    {
        private readonly IRepositoryManager _repositoryManager;

        public UserService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<IEnumerable<UserDto>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var users = await _repositoryManager.UserRepository.GetAsync(cancellationToken);

            var usersDto = users.Adapt<IEnumerable<UserDto>>();

            return usersDto;
        }

        public async Task<UserDto> CreateUserAsync(UserForCreateDto userForCreateDto, CancellationToken cancellationToken = default)
        {
            var user = userForCreateDto.Adapt<User>();

            _repositoryManager.UserRepository.Insert(user);

            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);

            return user.Adapt<UserDto>();
        }

        public async Task<UserDto> GetUserByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var user = await _repositoryManager.UserRepository.GetByIdAsync(id, cancellationToken);

            return user.Adapt<UserDto>();
        }
    }
}
