using Application.Users.Commands.UpdateUser;
using FluentValidation;

namespace Application.Users.Commands.DeleteUser
{
    public sealed class DeleteUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public DeleteUserCommandValidator()
        {
            RuleFor(x => x.UserId).NotEmpty();
        }
    }
}
