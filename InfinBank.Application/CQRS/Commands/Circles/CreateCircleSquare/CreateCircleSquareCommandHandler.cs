using InfinBank.Application.Interfaces;
using InfinBank.Application.Interfaces.ICalculateServices;
using InfinBank.Domain.Entities.Circle;
using MediatR;

namespace InfinBank.Application.CQRS.Commands.Circles.CreateCircleSquare;

public class CreateCircleSquareCommandHandler : IRequestHandler<CreateCircleSquareCommand, CircleSquareResponse>
{
    private readonly IInfinBankDBContext _dbContext;
    private readonly ICustomLoggingBehavoir _customLoggingBehavior;
    private readonly ICalculateCircleService _calculateCircleService;
    private readonly IDateTimeService _dateTimeService;
    private static readonly string _ClassName = nameof(CreateCircleSquareCommandHandler);

    public CreateCircleSquareCommandHandler(IInfinBankDBContext dbContext, ICustomLoggingBehavoir customLoggingBehavior, ICalculateCircleService calculateCircleService, IDateTimeService dateTimeService) => (_dbContext, _customLoggingBehavior, _calculateCircleService, _dateTimeService) = (dbContext, customLoggingBehavior, calculateCircleService, dateTimeService);

    public async Task<CircleSquareResponse> Handle(CreateCircleSquareCommand request, CancellationToken cancellationToken)
    {
        
        double square = _calculateCircleService.CalculateSquare(request.Radius);
        var circleEntity = new CircleEntity
        {
            Square = square,
            Radius= request.Radius
        };
        await _dbContext.CircleEntity.AddAsync(circleEntity, cancellationToken);
        var result = await _dbContext.SaveChangesAsync(cancellationToken);
        if (result > 0)
        {
            _customLoggingBehavior.WriteToFileSuccess(_ClassName, circleEntity);
        }
        CircleSquareResponse circleResponse = new CircleSquareResponse();
        circleResponse.Radius = request.Radius;
        circleResponse.Square = square;
        circleResponse.DateCreated = _dateTimeService.Now;

        return circleResponse;
    }
}