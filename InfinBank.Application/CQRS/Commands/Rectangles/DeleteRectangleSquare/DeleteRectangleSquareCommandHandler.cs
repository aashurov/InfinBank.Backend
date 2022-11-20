using InfinBank.Application.Common.Exceptions;
using InfinBank.Application.CQRS.Commands.Rectangles.DeleteRectanglePerimeter;
using InfinBank.Application.Interfaces;
using InfinBank.Domain.Entities.Rectangle;
using MediatR;

namespace InfinBank.Application.CQRS.Commands.Rectangles.DeleteRectangleSquare;

public class DeleteRectangleSquareCommandHandler : IRequestHandler<DeleteRectangleSquareCommand>
{
    private readonly IInfinBankDBContext _dbContext;
    private readonly ICustomLoggingBehavoir _customLoggingBehavior;
    private static readonly string _ClassName = nameof(DeleteRectanglePerimeterCommandHandler);

    public DeleteRectangleSquareCommandHandler(IInfinBankDBContext dbContext, ICustomLoggingBehavoir customLoggingBehavior) => (_dbContext, _customLoggingBehavior) = (dbContext, customLoggingBehavior);

    public async Task<Unit> Handle(DeleteRectangleSquareCommand request, CancellationToken cancellationToken)
    {
        var rectangleEntity = await _dbContext.RectangleEntity.FindAsync(new object[] { request.Id }, cancellationToken);

        if (rectangleEntity == null)
        {
            throw new NotFoundException(nameof(RectangleEntity), request.Id);
        }
        _dbContext.RectangleEntity.Remove(rectangleEntity);
        var result = await _dbContext.SaveChangesAsync(cancellationToken);

        if (result > 0)
        {
            _customLoggingBehavior.WriteToFileSuccess(_ClassName, rectangleEntity);
        }
        return Unit.Value;
    }
}