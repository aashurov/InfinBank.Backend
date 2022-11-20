using AutoMapper;
using InfinBank.Application.Common.Mappings;
using InfinBank.Domain.Entities.UserEntities;

namespace InfinBank.Application.Roles.Queries.GetRoleList;

public class RoleListLookupDto : IMapWith<Role>
{
    public string Id { get; set; }
    public string Name { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Role, RoleListLookupDto>()
            .ForMember(roleDto => roleDto.Id, opt => opt.MapFrom(role => role.Id))
            .ForMember(roleDto => roleDto.Name, opt => opt.MapFrom(role => role.Name));
    }
}