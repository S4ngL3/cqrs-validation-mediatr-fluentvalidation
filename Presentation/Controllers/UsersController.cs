using Application.Abstractions.Logging;
using Application.Logging.Commands;
using Application.Users.Commands.CreateUser;
using Application.Users.Commands.DeleteUser;
using Application.Users.Commands.UpdateUser;
using Application.Users.Queries.GetUserById;
using Application.Users.Queries.GetUsers;
using Contracts.Dtos.Users;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    /// <summary>
    /// The users controller.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public sealed class UsersController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IMediator _mediator;

        /// <summary>
        /// Initializes a new instance of the <see cref="UsersController"/> class.
        /// </summary>
        /// <param name="sender"></param>
        public UsersController(ILogger logger, IMediator mediator) {
            _logger = logger;
            _mediator = mediator; 
        }

        /// <summary>
        /// Gets all of the users.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The collection of users.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<UserDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetUsers(CancellationToken cancellationToken)
        {
            var query = new GetUsersQuery();
            _logger.Info(query);

            var users = await _mediator.Send(query, cancellationToken);
            _logger.Info(users);

            return Ok(users);
        }

        /// <summary>
        /// Gets the user with the specified identifier, if it exists.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The user with the specified identifier, if it exists.</returns>
        [HttpGet("{userId:int}")]
        [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetUserById(int userId, CancellationToken cancellationToken)
        {
            var query = new GetUserByIdQuery(userId);

            var user = await _mediator.Send(query, cancellationToken);

            return Ok(user);
        }

        /// <summary>
        /// Creates a new user based on the specified request.
        /// </summary>
        /// <param name="request">The create user request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The newly created user.</returns>
        [HttpPost]
        [ProducesResponseType(typeof(UserDto), StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest request, CancellationToken cancellationToken)
        {
            var command = request.Adapt<CreateUserCommand>();

            var user = await _mediator.Send(command, cancellationToken);

            return CreatedAtAction(nameof(GetUserById), new { userId = user.Id }, user);
        }

        /// <summary>
        /// Updates the user with the specified identifier based on the specified request, if it exists.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="request">The update user request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>No content.</returns>
        [HttpPut("{userId:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateUser(int userId, [FromBody] UpdateUserRequest request, CancellationToken cancellationToken)
        {
            var command = request.Adapt<UpdateUserCommand>() with
            {
                UserId = userId
            };

            await _mediator.Send(command, cancellationToken);

            return NoContent();
        }

        [HttpDelete("{userId:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteUser(int userId, CancellationToken cancellationToken)
        {
            var command = new DeleteUserCommand(userId);

            await _mediator.Send(command, cancellationToken);

            return Ok();
        }

    }
}
