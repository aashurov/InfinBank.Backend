using InfinBank.Application.Common.Exceptions;
using InfinBank.Domain.Entities.UserEntities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace InfinBank.Application.Users.Commands.DeleteUser;

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
{
    private readonly UserManager<User> _userManager;

    public DeleteUserCommandHandler(UserManager<User> userManager) => _userManager = userManager;

    public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var entity = await _userManager.FindByIdAsync(request.Id);

        if (entity == null)
        {
            throw new NotFoundException(nameof(User), request.Id);
        }

        await _userManager.DeleteAsync(await _userManager.FindByIdAsync(entity.Id));
        return Unit.Value;
    }
}