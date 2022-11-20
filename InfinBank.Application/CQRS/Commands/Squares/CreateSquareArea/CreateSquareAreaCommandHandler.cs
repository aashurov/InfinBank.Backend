using InfinBank.Application.Interfaces;
using InfinBank.Application.Interfaces.ICalculateServices;
using InfinBank.Domain.Entities.Square;
using MediatR;

namespace InfinBank.Application.CQRS.Commands.Squares.CreateSquareArea;

public class CreateSquareAreaCommandHandler : IRequestHandler<CreateSquareAreaCommand, SquareAreaResponse>
{
    private readonly IInfinBankDBContext _dbContext;
    private readonly ICustomLoggingBehavoir _customLoggingBehavior;
    private readonly ICalculateSquareService _calculateSquareService;
    private readonly IDateTimeService _dateTimeService;
    private static readonly string _ClassName = nameof(CreateSquareAreaCommandHandler);

    public CreateSquareAreaCommandHandler(IInfinBankDBContext dbContext, ICustomLoggingBehavoir customLoggingBehavior, ICalculateSquareService calculateSquareService, IDateTimeService dateTimeService) => (_dbContext, _customLoggingBehavior, _calculateSquareService, _dateTimeService) = (dbContext, customLoggingBehavior, calculateSquareService, dateTimeService);

    public async Task<SquareAreaResponse> Handle(CreateSquareAreaCommand request, CancellationToken cancellationToken)
    {
        double area = _calculateSquareService.CalculateSquare(request.Side);
        var squareEntity = new SquareEntity
        {
            Area = area,
            Side = request.Side
        };
        await _dbContext.SquareEntity.AddAsync(squareEntity, cancellationToken);
        var result = await _dbContext.SaveChangesAsync(cancellationToken);
        if (result > 0)
        {
            _customLoggingBehavior.WriteToFileSuccess(_ClassName, squareEntity);
        }
        SquareAreaResponse squareAreaResponse = new SquareAreaResponse();
        squareAreaResponse.Side = request.Side;
        squareAreaResponse.Area = area;
        squareAreaResponse.DateCreated = _dateTimeService.Now;

        return squareAreaResponse;
    }
}