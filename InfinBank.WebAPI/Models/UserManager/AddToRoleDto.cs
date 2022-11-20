using AutoMapper;
using InfinBank.Application.Common.Mappings;
using InfinBank.Application.Users.Commands.AddToRole;
using System.ComponentModel.DataAnnotations;

namespace InfinBank.WebApi.Models.UserManager;

/// <summary>
///
/// </summary>
public class AddToRoleDto : IMapWith<AddToRoleCommand>
{
    /// <summary>
    ///
    /// </summary>
    [Required]
    public string RoleId { get; set; }

    /// <summary>
    ///
    /// </summary>
    [Required]
    public string UserId { get; set; }

    /// <summary>
    ///
    /// </summary>
    public void Mapping(Profile profile)
    {
        profile.CreateMap<AddToRoleDto, AddToRoleCommand>()
            .ForMember(addToRoleCommand => addToRoleCommand.UserId,
                options => options.MapFrom(addToRoleDto => addToRoleDto.UserId))
            .ForMember(addToRoleCommand => addToRoleCommand.RoleId,
                options => options.MapFrom(addToRoleDto => addToRoleDto.RoleId));
    }
}