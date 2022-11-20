using InfinBank.Application.Common.Exceptions;
using InfinBank.Application.Interfaces;
using InfinBank.Domain.Entities.Square;
using MediatR;

namespace InfinBank.Application.CQRS.Commands.Squares.DeleteSquareArea;

public class DeleteSquareAreaCommandHandler : IRequestHandler<DeleteSquareAreaCommand>
{
    private readonly IInfinBankDBContext _dbContext;
    private readonly ICustomLoggingBehavoir _customLoggingBehavior;
    private static readonly string _ClassName = nameof(DeleteSquareAreaCommandHandler);

    public DeleteSquareAreaCommandHandler(IInfinBankDBContext dbContext, ICustomLoggingBehavoir customLoggingBehavior) => (_dbContext, _customLoggingBehavior) = (dbContext, customLoggingBehavior);

    public async Task<Unit> Handle(DeleteSquareAreaCommand request, CancellationToken cancellationToken)
    {
        var squareEntity = await _dbContext.SquareEntity.FindAsync(new object[] { request.Id }, cancellationToken);

        if (squareEntity == null)
        {
            throw new NotFoundException(nameof(SquareEntity), request.Id);
        }
        _dbContext.SquareEntity.Remove(squareEntity);
        var result = await _dbContext.SaveChangesAsync(cancellationToken);

        if (result > 0)
        {
            _customLoggingBehavior.WriteToFileSuccess(_ClassName, squareEntity);
        }
        return Unit.Value;
    }
}