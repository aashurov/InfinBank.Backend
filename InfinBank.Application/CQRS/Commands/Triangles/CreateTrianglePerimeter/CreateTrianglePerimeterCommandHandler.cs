using InfinBank.Application.Interfaces;
using InfinBank.Application.Interfaces.ICalculateServices;
using InfinBank.Domain.Entities.Triangle;
using MediatR;

namespace InfinBank.Application.CQRS.Commands.Triangles.CreateTrianglePerimeter;

public class CreateTrianglePerimeterCommandHandler : IRequestHandler<CreateTrianglePerimeterCommand, TrianglePerimeterResponse>
{
    private readonly IInfinBankDBContext _dbContext;
    private readonly ICustomLoggingBehavoir _customLoggingBehavior;
    private readonly ICalculateTriangleService _calculateTriangleService;
    private readonly IDateTimeService _dateTimeService;
    private static readonly string _ClassName = nameof(CreateTrianglePerimeterCommandHandler);

    public CreateTrianglePerimeterCommandHandler(IInfinBankDBContext dbContext, ICustomLoggingBehavoir customLoggingBehavior, ICalculateTriangleService calculateTriangleService, IDateTimeService dateTimeService) => (_dbContext, _customLoggingBehavior, _calculateTriangleService, _dateTimeService) = (dbContext, customLoggingBehavior, calculateTriangleService, dateTimeService);

    public async Task<TrianglePerimeterResponse> Handle(CreateTrianglePerimeterCommand request, CancellationToken cancellationToken)
    {
        double perimeter = _calculateTriangleService.CalculatePerimeter(request.ASide, request.BSide, request.CSide);
        var triangleEntity = new TriangleEntity
        {
            ASide = request.ASide,
            BSide = request.BSide,
            CSide = request.CSide,
            Perimeter = perimeter
        };
        await _dbContext.TriangleEntity.AddAsync(triangleEntity, cancellationToken);
        var result = await _dbContext.SaveChangesAsync(cancellationToken);
        if (result > 0)
        {
            _customLoggingBehavior.WriteToFileSuccess(_ClassName, triangleEntity);
        }
        TrianglePerimeterResponse trianglePerimeterResponse = new TrianglePerimeterResponse();
        trianglePerimeterResponse.ASide = request.ASide;
        trianglePerimeterResponse.BSide = request.BSide;
        trianglePerimeterResponse.CSide = request.CSide;
        trianglePerimeterResponse.Perimeter = perimeter;
        trianglePerimeterResponse.DateCreated = _dateTimeService.Now;
        return trianglePerimeterResponse;
    }
}