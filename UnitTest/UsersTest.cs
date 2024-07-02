using Application.Users.Queries.GetUsers;
using Contracts.Dtos.Users;
using Contracts.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using NUnit.Framework;
using Presentation.Controllers;
using Services;
using System.Threading;

namespace UnitTest
{
    public class UsersTest
    {
        private readonly Mock<IMediator> _mediator;
        private readonly Mock<IServiceManager> _serviceManager;
        private readonly Mock<IRepositoryManager> _repositoryManager;
        private readonly UsersController _usersController;

        public UsersTest() {
            _mediator = new Mock<IMediator>();
            _usersController = new UsersController(_mediator.Object);
            _repositoryManager = new Mock<IRepositoryManager>();
            _serviceManager = new Mock<IServiceManager>();
        }

        [Fact]
        public async void GetUsersTest()
        {
            //        var query = new GetUsersQuery();
            //        _mediator.Setup(x => x.Send(new GetUsersQuery(),
            //It.IsAny<CancellationToken>())).Returns(Task.FromResult(List<UserDto>()));
            //var users = _mediator.Object.Send(query, new System.Threading.CancellationToken());

            GetUsersQueryHandler handler = new Application.Users.Queries.GetUsers.GetUsersQueryHandler(_serviceManager.Object);

            var x = await handler.Handle(new GetUsersQuery(), new System.Threading.CancellationToken());

            // Assert
            // TODO: Validate the Result


        }
    }
}