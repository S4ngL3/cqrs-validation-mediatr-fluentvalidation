using Contracts.Repositories;
using MediatR;
using Moq;
using Presentation.Controllers;

namespace UnitTest
{
    public class UsersTest
    {
        private readonly Mock<IMediator> _mediator;
        private readonly Mock<IRepositoryManager> _repositoryManager;
        private readonly UsersController _usersController;

        public UsersTest()
        {
            _mediator = new Mock<IMediator>();
            _usersController = new UsersController(_mediator.Object);
            _repositoryManager = new Mock<IRepositoryManager>();
        }

        [Fact]
        public async void GetUsersTest()
        {
            var res = _usersController.GetUsers(new CancellationToken());


        }
    }
}