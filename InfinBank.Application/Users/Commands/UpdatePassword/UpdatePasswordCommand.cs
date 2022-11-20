using MediatR;

namespace InfinBank.Application.Users.Commands.UpdatePassword;

public class UpdatePasswordCommand : IRequest
{
    public string UserId { get; set; }
    public string PasswordHash { get; set; }
}