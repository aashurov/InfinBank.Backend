using InfinBank.Application.Interfaces;
using InfinBank.Application.Interfaces.ICalculateServices;
using InfinBank.Domain.Entities.Triangle;
using MediatR;

namespace InfinBank.Application.CQRS.Commands.Triangles.CreateTriangleArea;

public class CreateTriangleAreaCommandHandler : IRequestHandler<CreateTriangleAreaCommand, TriangleSquareResponse>
{
    private readonly IInfinBankDBContext _dbContext;
    private readonly ICustomLoggingBehavoir _customLoggingBehavior;
    private readonly ICalculateTriangleService _calculateTriangleService;
    private readonly IDateTimeService _dateTimeService;
    private static readonly string _ClassName = nameof(CreateTriangleAreaCommandHandler);

    public CreateTriangleAreaCommandHandler(IInfinBankDBContext dbContext, ICustomLoggingBehavoir customLoggingBehavior, ICalculateTriangleService calculateTriangleService, IDateTimeService dateTimeService) => (_dbContext, _customLoggingBehavior, _calculateTriangleService, _dateTimeService) = (dbContext, customLoggingBehavior, calculateTriangleService, dateTimeService);

    public async Task<TriangleSquareResponse> Handle(CreateTriangleAreaCommand request, CancellationToken cancellationToken)
    {
        double square = _calculateTriangleService.CalculateSquare(request.ASide, request.BSide, request.CSide);
        var triangleEntity = new TriangleEntity
        {
            ASide = request.ASide,
            BSide = request.BSide,
            CSide = request.CSide,
            Square = square
        };
        await _dbContext.TriangleEntity.AddAsync(triangleEntity, cancellationToken);
        var result = await _dbContext.SaveChangesAsync(cancellationToken);
        if (result > 0)
        {
            _customLoggingBehavior.WriteToFileSuccess(_ClassName, triangleEntity);
        }
        TriangleSquareResponse triangleSquareResponse = new TriangleSquareResponse();
        triangleSquareResponse.ASide = request.ASide;
        triangleSquareResponse.BSide = request.BSide;
        triangleSquareResponse.CSide = request.CSide;
        triangleSquareResponse.Square = square;
        triangleSquareResponse.DateCreated = _dateTimeService.Now;
        return triangleSquareResponse;
    }
}