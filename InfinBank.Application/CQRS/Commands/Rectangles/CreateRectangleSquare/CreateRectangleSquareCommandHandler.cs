using InfinBank.Application.Interfaces;
using InfinBank.Application.Interfaces.ICalculateServices;
using InfinBank.Domain.Entities.Rectangle;
using MediatR;

namespace InfinBank.Application.CQRS.Commands.Rectangles.CreateRectangleSquare;

public class CreateRectangleSquareCommandHandler : IRequestHandler<CreateRectangleSquareCommand, RectangleSquareResponse>
{
    private readonly IInfinBankDBContext _dbContext;
    private readonly ICustomLoggingBehavoir _customLoggingBehavior;
    private readonly ICalculateRectangleService _calculateRectangleService;
    private readonly IDateTimeService _dateTimeService;
    private static readonly string _ClassName = nameof(CreateRectangleSquareCommandHandler);

    public CreateRectangleSquareCommandHandler(IInfinBankDBContext dbContext, ICustomLoggingBehavoir customLoggingBehavior, ICalculateRectangleService calculateRectangleService, IDateTimeService dateTimeService) => (_dbContext, _customLoggingBehavior, _calculateRectangleService, _dateTimeService) = (dbContext, customLoggingBehavior, calculateRectangleService, dateTimeService);

    public async Task<RectangleSquareResponse> Handle(CreateRectangleSquareCommand request, CancellationToken cancellationToken)
    {
        double square = _calculateRectangleService.CalculateSquare(request.Width, request.Length);
        var rectangleEntity = new RectangleEntity
        {
            Square = square,
            Length = request.Length,
            Width = request.Width
        };
        await _dbContext.RectangleEntity.AddAsync(rectangleEntity, cancellationToken);
        var result = await _dbContext.SaveChangesAsync(cancellationToken);
        if (result > 0)
        {
            _customLoggingBehavior.WriteToFileSuccess(_ClassName, rectangleEntity);
        }
        RectangleSquareResponse rectangleSquareResponse = new RectangleSquareResponse();
        rectangleSquareResponse.Width = request.Width;
        rectangleSquareResponse.Length = request.Length;
        rectangleSquareResponse.Square = square;
        rectangleSquareResponse.DateCreated = _dateTimeService.Now;
        return rectangleSquareResponse;
    }
}