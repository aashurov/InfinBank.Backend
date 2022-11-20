 using InfinBank.Application.Common.Exceptions;
using InfinBank.Domain.Entities.UserEntities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Threading;
using System.Threading.Tasks;

namespace InfinBank.Application.Roles.Commands.UpdateRole;

public class UpdateRoleCommandHandler : IRequestHandler<UpdateRoleCommand>
{
    private readonly RoleManager<Role> _roleManager;

    public UpdateRoleCommandHandler(RoleManager<Role> roleManager) => _roleManager = roleManager;

    public async Task<Unit> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
    {
        var entity = await _roleManager.FindByIdAsync(request.Id);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Role), request.Id);
        }
        entity.Name = request.Name;
        await _roleManager.UpdateAsync(entity);
        return Unit.Value;
    }
}