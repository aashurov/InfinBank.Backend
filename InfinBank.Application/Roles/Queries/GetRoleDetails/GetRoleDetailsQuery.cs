using MediatR;

namespace InfinBank.Application.Roles.Queries.GetRoleDetails;

public class GetRoleDetailsQuery : IRequest<RoleDetailsVm>
{
    public string Id { get; set; }
    public string Name { get; set; }
}