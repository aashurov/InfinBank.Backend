using InfinBank.Application.Interfaces;
using InfinBank.Application.Interfaces.ICalculateServices;
using InfinBank.Domain.Entities.Rectangle;
using MediatR;

namespace InfinBank.Application.CQRS.Commands.Rectangles.CreateRectanglePerimeter;

public class CreateRectanglePerimeterCommandHandler : IRequestHandler<CreateRectanglePerimeterCommand, RectanglePerimeterResponse>
{
    private readonly IInfinBankDBContext _dbContext;
    private readonly ICustomLoggingBehavoir _customLoggingBehavior;
    private readonly ICalculateRectangleService _calculateRectangleService;
    private readonly IDateTimeService _dateTimeService;
    private static readonly string _ClassName = nameof(CreateRectanglePerimeterCommandHandler);

    public CreateRectanglePerimeterCommandHandler(IInfinBankDBContext dbContext, ICustomLoggingBehavoir customLoggingBehavior, ICalculateRectangleService calculateRectangleService, IDateTimeService dateTimeService) => (_dbContext, _customLoggingBehavior, _calculateRectangleService, _dateTimeService) = (dbContext, customLoggingBehavior, calculateRectangleService, dateTimeService);

    public async Task<RectanglePerimeterResponse> Handle(CreateRectanglePerimeterCommand request, CancellationToken cancellationToken)
    {
        double perimeter = _calculateRectangleService.CalculatePerimeter(request.Width, request.Length);
        var rectangleEntity = new RectangleEntity
        {
            Perimeter = perimeter,
            Length= request.Length,
            Width = request.Width

        };
        await _dbContext.RectangleEntity.AddAsync(rectangleEntity, cancellationToken);
        var result = await _dbContext.SaveChangesAsync(cancellationToken);
        if (result > 0)
        {
            _customLoggingBehavior.WriteToFileSuccess(_ClassName, rectangleEntity);
        }
        RectanglePerimeterResponse rectanglePerimeterResponse = new RectanglePerimeterResponse();
        rectanglePerimeterResponse.Width = request.Width;
        rectanglePerimeterResponse.Length = request.Length;
        rectanglePerimeterResponse.Perimeter = perimeter;
        rectanglePerimeterResponse.DateCreated = _dateTimeService.Now;
        return rectanglePerimeterResponse;
    }
}