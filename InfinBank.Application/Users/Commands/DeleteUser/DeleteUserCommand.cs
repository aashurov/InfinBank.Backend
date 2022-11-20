using MediatR;

namespace InfinBank.Application.Users.Commands.DeleteUser;

public class DeleteUserCommand : IRequest
{
    public string Id { get; set; }
}