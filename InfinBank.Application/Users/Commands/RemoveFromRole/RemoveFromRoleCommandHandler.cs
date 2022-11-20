using InfinBank.Application.Common.Exceptions;
using InfinBank.Domain.Entities.UserEntities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace InfinBank.Application.Users.Commands.DeleteFromRole;

public class DeleteFromRoleCommandHandler : IRequestHandler<DeleteFromRoleCommand>
{
    private readonly UserManager<User> _userManager;
    private readonly RoleManager<Role> _roleManager;

    public DeleteFromRoleCommandHandler(UserManager<User> userManager, RoleManager<Role> roleManager) => (_userManager, _roleManager) = (userManager, roleManager);

    public async Task<Unit> Handle(DeleteFromRoleCommand request, CancellationToken cancellationToken)
    {
        var entity = await _userManager.FindByIdAsync(request.UserId);

        if (entity == null)
        {
            throw new NotFoundException(nameof(User), request.UserId);
        }

        var entityRole = await _roleManager.FindByIdAsync(request.RoleId);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Role), request.RoleId);
        }

        await _userManager.RemoveFromRoleAsync(entity, _roleManager.FindByIdAsync(request.RoleId).Result.Name);
        return Unit.Value;
    }
}