using AutoMapper;
using InfinBank.Application.Common.Exceptions;
using InfinBank.Domain.Entities.UserEntities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace InfinBank.Application.Roles.Queries.GetRoleDetails;

public class GetRoleDetailsQueryHandler : IRequestHandler<GetRoleDetailsQuery, RoleDetailsVm>
{
    private readonly IMapper _mapper;
    private readonly RoleManager<Role> _roleManager;

    public GetRoleDetailsQueryHandler(RoleManager<Role> roleManager, IMapper mapper) => (_roleManager, _mapper) = (roleManager, mapper);

    public async Task<RoleDetailsVm> Handle(GetRoleDetailsQuery request, CancellationToken cancellationToken)
    {
        var entity = await _roleManager.FindByIdAsync(request.Id);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Role), request.Id);
        }
        return _mapper.Map<RoleDetailsVm>(entity);
    }
}