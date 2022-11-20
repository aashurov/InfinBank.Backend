﻿using AutoMapper;
using InfinBank.Application.Common.Exceptions;
using InfinBank.Domain.Entities.UserEntities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace InfinBank.Application.Users.Queries.GetUserDetails;

public class GetUserDetailsQueryHandler : IRequestHandler<GetUserDetailsQuery, UserDetailsVm>
{
    private readonly IMapper _mapper;

    private readonly UserManager<User> _userManager;

    public GetUserDetailsQueryHandler(UserManager<User> userManager, IMapper mapper) => (_userManager, _mapper) = (userManager, mapper);

    public async Task<UserDetailsVm> Handle(GetUserDetailsQuery request, CancellationToken cancellationToken)
    {
        var entity = await _userManager.Users
                                            .Include(p => p.UserRoles).ThenInclude(e => e.Role)
                                            .FirstOrDefaultAsync(userDetails => userDetails.Id == request.Id, cancellationToken);
        if (entity == null)
        {
            throw new NotFoundException(nameof(User), request.Id);
        }
        return _mapper.Map<UserDetailsVm>(entity);
    }
}