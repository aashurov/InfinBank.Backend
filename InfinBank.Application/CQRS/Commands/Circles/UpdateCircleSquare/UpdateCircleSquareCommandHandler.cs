using InfinBank.Application.Common.Exceptions;
using InfinBank.Application.Interfaces;
using InfinBank.Application.Interfaces.ICalculateServices;
using InfinBank.Domain.Entities.Circle;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace InfinBank.Application.CQRS.Commands.Circles.UpdateCircleSquare;

public class UpdateCircleSquareCommandHandler : IRequestHandler<UpdateCircleSquareCommand, CircleSquareResponse>
{
    private readonly IInfinBankDBContext _dbContext;
    private readonly ICustomLoggingBehavoir _customLoggingBehavior;
    private readonly ICalculateCircleService _calculateCircleService;
    private static readonly string _ClassName = nameof(UpdateCircleSquareCommandHandler);

    public UpdateCircleSquareCommandHandler(IInfinBankDBContext dbContext, ICustomLoggingBehavoir customLoggingBehavior, ICalculateCircleService calculateCircleService) => (_dbContext, _customLoggingBehavior, _calculateCircleService) = (dbContext, customLoggingBehavior, calculateCircleService);

    public async Task<CircleSquareResponse> Handle(UpdateCircleSquareCommand request, CancellationToken cancellationToken)
    {
        double square = _calculateCircleService.CalculateCircumference(request.Radius);

        var circleEntity = await _dbContext.CircleEntity.FirstOrDefaultAsync(circleEntity => circleEntity.Id == request.Id, cancellationToken);

        if (circleEntity == null)
        {
            throw new NotFoundException(nameof(CircleEntity), request.Id);
        }

        circleEntity.Square = square;
        circleEntity.Radius = request.Radius;

        var result = await _dbContext.SaveChangesAsync(cancellationToken);
        if (result > 0)
        {
            _customLoggingBehavior.WriteToFileSuccess(_ClassName, circleEntity);
        }
        CircleSquareResponse circleSquareResponse = new CircleSquareResponse();
        circleSquareResponse.Square = square;
        circleSquareResponse.Radius = request.Radius;
        circleSquareResponse.DateCreated = circleEntity.DateCreated;
        circleSquareResponse.DateUpdated = circleEntity.DateUpdated;
        
        return circleSquareResponse;
    }
}