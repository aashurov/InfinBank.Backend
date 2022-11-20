﻿using AutoMapper;
using InfinBank.Application.Common.Mappings;
using InfinBank.Application.Users.Commands.UpdateUserRole;

namespace InfinBank.WebApi.Models.UserManager;

/// <summary>
///
/// </summary>
public class UpdateUserRoleDto : IMapWith<UpdateUserRoleCommand>
{
    ///// <summary>
    /////
    ///// </summary>
    //public int Id { get; set; }
    /// <summary>
    ///
    /// </summary>
    public string UserId { get; set; }

    /// <summary>
    ///
    /// </summary>
    public string NewRoleId { get; set; }

    /// <summary>
    ///
    /// </summary>
    public string OldRoleId { get; set; }

    /// <summary>
    ///
    /// </summary>
    public void Mapping(Profile profile)
    {
        profile.CreateMap<UpdateUserRoleDto, UpdateUserRoleCommand>()
            .ForMember(updateUserCommand => updateUserCommand.NewRoleId,
                options => options.MapFrom(updateUserDto => updateUserDto.NewRoleId))
            .ForMember(updateUserCommand => updateUserCommand.OldRoleId,
                options => options.MapFrom(updateUserDto => updateUserDto.OldRoleId));
    }
}