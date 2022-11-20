﻿using AutoMapper;
using InfinBank.Application.Common.Mappings;
using InfinBank.Application.Users.Commands.UpdateUser;

namespace InfinBank.WebApi.Models.UserManager;

/// <summary>
///
/// </summary>
public class UpdateUserDto : IMapWith<UpdateUserCommand>
{
    /// <summary>
    ///
    /// </summary>
    public string Id { get; set; }

    /// <summary>
    ///
    /// </summary>
    public string FirstName { get; set; }

    /// <summary>
    ///
    /// </summary>
    public string LastName { get; set; }

    /// <summary>
    ///
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    ///
    /// </summary>
    public string Address { get; set; }

    /// <summary>
    ///
    /// </summary>
    public string PhoneNumber { get; set; }

    /// <summary>
    ///
    /// </summary>
    public void Mapping(Profile profile)
    {
        profile.CreateMap<UpdateUserDto, UpdateUserCommand>()
            .ForMember(updateUserCommand => updateUserCommand.Id,
                options => options.MapFrom(updateUserDto => updateUserDto.Id))
            .ForMember(updateUserCommand => updateUserCommand.FirstName,
                options => options.MapFrom(updateUserDto => updateUserDto.LastName))
            .ForMember(updateUserCommand => updateUserCommand.Address,
                options => options.MapFrom(updateUserDto => updateUserDto.Address))
            .ForMember(updateUserCommand => updateUserCommand.Email,
                options => options.MapFrom(updateUserDto => updateUserDto.Email))
        .ForMember(updateUserCommand => updateUserCommand.PhoneNumber,
                options => options.MapFrom(updateUserDto => updateUserDto.PhoneNumber))
        .ForMember(updateUserCommand => updateUserCommand.Address,
                options => options.MapFrom(updateUserDto => updateUserDto.Address));
    }
}