using InfinBank.Application.Authentication.Commands.Tokens.RefreshTokens;
using InfinBank.Application.Interfaces;
using InfinBank.Domain.Entities.UserEntities;
using MediatR;
using System.Reflection;

namespace InfinBank.Application.Authentication.Commands.Tokens.RefreshTokens;

public class RefreshTokenCommandHandler : IRequestHandler<RefreshTokenCommand>
{
    private readonly IInfinBankDBContext _dbContext;
    private readonly ICustomLoggingBehavoir _customLoggingBehavior;

    public RefreshTokenCommandHandler(IInfinBankDBContext dbContext, ICustomLoggingBehavoir customLoggingBehavior) => (_dbContext, _customLoggingBehavior) = (dbContext, customLoggingBehavior);

    public async Task<Unit> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
    {
        var token = new RefreshToken
        {
            Token = request.Token,
            UserId = request.UserId,
            JwtId = request.JwtId,
            IsUsed = request.IsUsed,
            IsRevoked = request.IsRevoked
        };

        await _dbContext.RefreshToken.AddAsync(token, cancellationToken);
        int result = await _dbContext.SaveChangesAsync(cancellationToken);
        string className = MethodBase.GetCurrentMethod().DeclaringType.Name;

        if (result > 0)
        {
            _customLoggingBehavior.WriteToFileSuccess(className, token);
        }
        return Unit.Value;
    }
}