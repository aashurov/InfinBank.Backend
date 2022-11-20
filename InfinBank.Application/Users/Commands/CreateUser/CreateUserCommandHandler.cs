﻿using InfinBank.Application.Interfaces;
using InfinBank.Domain.Entities.UserEntities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace InfinBank.Application.Users.Commands.CreateUser;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, string>
{
    private readonly UserManager<User> _userManager;
    private readonly ICustomLoggingBehavoir _customLoggingBehavior;

    public CreateUserCommandHandler(UserManager<User> userManager, ICustomLoggingBehavoir customLoggingBehavior) => (_userManager, _customLoggingBehavior) = (userManager, customLoggingBehavior);

    public async Task<string> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var password = new PasswordHasher<User>();
        Func<string> GenerateSecurityStamp = delegate ()
        {
            var guid = Guid.NewGuid();
            return String.Concat(Array.ConvertAll(guid.ToByteArray(), b => b.ToString("X2")));
        };

        var user = new User
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            UserName = request.UserName,
            NormalizedUserName = request.UserName.Normalize(),
            Email = request.Email,
            NormalizedEmail = request.Email.Normalize(),
            Address = request.Address,
            PhoneNumber = request.PhoneNumber
        };

        var hashed = password.HashPassword(user, request.PasswordHash);
        user.PasswordHash = hashed;
        var isCreateAsync = await _userManager.CreateAsync(user, hashed);
        var isAddToRoleAsync = await _userManager.AddToRoleAsync(user, request.RoleName);
        var isCreatedSecurityStamp = await _userManager.UpdateSecurityStampAsync(user);
        string response = "Error";
        if (isCreateAsync.Succeeded)
        {
            response = user.Id;
            //_customLoggingBehavior.WriteToFileSuccess(user);
        }
        else
        {
            response = isCreateAsync.Errors.ToString();
        }

        if (isAddToRoleAsync.Succeeded)
        {
            response = user.Id;
        }
        else
        {
            response = isAddToRoleAsync.Errors.ToString();
        }

        if (isCreatedSecurityStamp.Succeeded)
        {
            response = user.Id;
        }
        else
        {
            response = isCreatedSecurityStamp.Errors.ToString();
        }

        return response;
    }
}