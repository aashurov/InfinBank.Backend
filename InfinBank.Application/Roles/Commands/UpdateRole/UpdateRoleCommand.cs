using MediatR;

namespace InfinBank.Application.Roles.Commands.UpdateRole;

public class UpdateRoleCommand : IRequest
{
    public string Id { get; set; }
    public string Name { get; set; }
}