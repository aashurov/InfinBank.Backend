using MediatR;

namespace InfinBank.Application.Users.Queries.GetUserList;

public class GetUserListQuery : IRequest<UserListVm>
{
}