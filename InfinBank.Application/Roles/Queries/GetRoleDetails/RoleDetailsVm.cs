using AutoMapper;
using InfinBank.Application.Common.Mappings;
using InfinBank.Domain.Entities.UserEntities;

namespace InfinBank.Application.Roles.Queries.GetRoleDetails;

public class RoleDetailsVm : IMapWith<Role>
{
    public string Id { get; set; }
    public string Name { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Role, RoleDetailsVm>()
            .ForMember(userVm => userVm.Id, opt => opt.MapFrom(customer => customer.Id))
            .ForMember(userVm => userVm.Name, opt => opt.MapFrom(customer => customer.Name));
    }
}