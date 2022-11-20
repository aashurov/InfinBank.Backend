using InfinBank.Domain.Entities.UserEntities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace InfinBank.Application.Roles.Commands.CreateRole;

public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand, string>
{
    private readonly RoleManager<Role> _roleManager;

    public CreateRoleCommandHandler(RoleManager<Role> roleManager) => _roleManager = roleManager;

    public async Task<string> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
    {
        var role = new Role
        {
            Name = request.Name,
        };

        await _roleManager.CreateAsync(role);

        return role.Id;
    }
}