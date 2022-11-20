using InfinBank.Application.Common.Exceptions;
using InfinBank.Domain.Entities.UserEntities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace InfinBank.Application.Roles.Commands.DeleteRole;

public class DeleteRoleCommandHandler : IRequestHandler<DeleteRoleCommand>
{
    private readonly RoleManager<Role> _roleManager;

    public DeleteRoleCommandHandler(RoleManager<Role> roleManager) => _roleManager = roleManager;

    public async Task<Unit> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
    {
        var entity = await _roleManager.FindByIdAsync(request.Id);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Role), request.Id);
        }

        await _roleManager.DeleteAsync(await _roleManager.FindByIdAsync(entity.Id));
        return Unit.Value;
    }
}