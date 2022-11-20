using InfinBank.Application.Interfaces;
using InfinBank.Application.Interfaces.ICalculateServices;
using InfinBank.Domain.Entities.Square;
using MediatR;

namespace InfinBank.Application.CQRS.Commands.Squares.CreateSquarePerimeter;

public class CreateSquarePerimeterCommandHandler : IRequestHandler<CreateSquarePerimeterCommand, SquarePerimeterResponse>
{
    private readonly IInfinBankDBContext _dbContext;
    private readonly ICustomLoggingBehavoir _customLoggingBehavior;
    private readonly ICalculateSquareService _calculateSquareService;
    private readonly IDateTimeService _dateTimeService;
    private static readonly string _ClassName = nameof(CreateSquarePerimeterCommandHandler);

    public CreateSquarePerimeterCommandHandler(IInfinBankDBContext dbContext, ICustomLoggingBehavoir customLoggingBehavior, ICalculateSquareService calculateSquareService, IDateTimeService dateTimeService) => (_dbContext, _customLoggingBehavior, _calculateSquareService, _dateTimeService) = (dbContext, customLoggingBehavior, calculateSquareService, dateTimeService);

    public async Task<SquarePerimeterResponse> Handle(CreateSquarePerimeterCommand request, CancellationToken cancellationToken)
    {
        double perimeter = _calculateSquareService.CalculatePerimeter(request.Side);
        var squareEntity = new SquareEntity
        {
            Perimeter = perimeter,
            Side = request.Side
        };
        await _dbContext.SquareEntity.AddAsync(squareEntity, cancellationToken);
        var result = await _dbContext.SaveChangesAsync(cancellationToken);
        if (result > 0)
        {
            _customLoggingBehavior.WriteToFileSuccess(_ClassName, squareEntity);
        }
        SquarePerimeterResponse squarePerimeterResponse = new SquarePerimeterResponse();
        squarePerimeterResponse.Side = request.Side;
        squarePerimeterResponse.Perimeter = perimeter;
        squarePerimeterResponse.DateCreated = _dateTimeService.Now;

        return squarePerimeterResponse;
    }
}