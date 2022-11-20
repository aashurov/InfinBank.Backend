using InfinBank.Application.Common.Exceptions;
using InfinBank.Application.Interfaces;
using InfinBank.Domain.Entities.Circle;
using MediatR;

namespace InfinBank.Application.CQRS.Commands.Circles.DeleteCircleCircumference;

public class DeleteCircleCircumferenceCommandHandler : IRequestHandler<DeleteCircleCircumferenceCommand>
{
    private readonly IInfinBankDBContext _dbContext;
    private readonly ICustomLoggingBehavoir _customLoggingBehavior;
    private static readonly string _ClassName = nameof(DeleteCircleCircumferenceCommandHandler);

    public DeleteCircleCircumferenceCommandHandler(IInfinBankDBContext dbContext, ICustomLoggingBehavoir customLoggingBehavior) => (_dbContext, _customLoggingBehavior) = (dbContext, customLoggingBehavior);

    public async Task<Unit> Handle(DeleteCircleCircumferenceCommand request, CancellationToken cancellationToken)
    {
        var circleEntity = await _dbContext.CircleEntity.FindAsync(new object[] { request.Id }, cancellationToken);

        if (circleEntity == null)
        {
            throw new NotFoundException(nameof(CircleEntity), request.Id);
        }
        _dbContext.CircleEntity.Remove(circleEntity);
        var result = await _dbContext.SaveChangesAsync(cancellationToken);

        if (result > 0)
        {
            _customLoggingBehavior.WriteToFileSuccess(_ClassName, circleEntity);
        }
        return Unit.Value;
    }
}