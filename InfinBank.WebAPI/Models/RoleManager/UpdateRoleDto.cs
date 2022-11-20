﻿using AutoMapper;
using InfinBank.Application.Common.Mappings;
using InfinBank.Application.Roles.Commands.UpdateRole;
using System.ComponentModel.DataAnnotations;

namespace InfinBank.WebApi.Models.RoleManager;

/// <summary>
///
/// </summary>
public class UpdateRoleDto : IMapWith<UpdateRoleCommand>
{
    /// <summary>
    ///
    /// </summary>
    [Required]
    public string Id { get; set; }

    /// <summary>
    ///
    /// </summary>

    [Required]
    public string Name { get; set; }

    /// <summary>
    ///
    /// </summary>

    public void Mapping(Profile profile)
    {
        profile.CreateMap<UpdateRoleDto, UpdateRoleCommand>()
            .ForMember(updateRoleCommand => updateRoleCommand.Id,
                options => options.MapFrom(updateRoleDto => updateRoleDto.Id))
            .ForMember(updateRoleCommand => updateRoleCommand.Name,
                options => options.MapFrom(updateRoleDto => updateRoleDto.Name));
    }
}