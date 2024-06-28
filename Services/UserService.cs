using Contracts.Dtos.Users;
using Contracts.Entities;
using Contracts.Exceptions;
using Contracts.Repositories;
using Mapster;
using Services.Abstractions;

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

        public async Task UpdateUserAsync(int id, UserForUpdateDto userForUpdateDto, CancellationToken cancellationToken = default)
        {
            var user = await _repositoryManager.UserRepository.GetByIdAsync(id, cancellationToken);

            if (user == null)
            {
                throw new UserNotFoundException(id);
            }

            user.FirstName = userForUpdateDto.FirstName;
            user.LastName = userForUpdateDto.LastName;

            _repositoryManager.UserRepository.Update(user);

            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        }
        public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var user = await _repositoryManager.UserRepository.GetByIdAsync(id, cancellationToken);

            if (user == null)
            {
                throw new UserNotFoundException(id);
            }

            _repositoryManager.UserRepository.Delete(user);

            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
