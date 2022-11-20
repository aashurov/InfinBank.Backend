using InfinBank.Application.Common.Exceptions;
using InfinBank.Application.Interfaces;
using InfinBank.Application.Interfaces.ICalculateServices;
using InfinBank.Domain.Entities.Circle;
using InfinBank.Domain.Entities.Rectangle;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace InfinBank.Application.CQRS.Commands.Rectangles.UpdateRectanglePerimeter;

public class UpdateRectanglePerimeterCommandHandler : IRequestHandler<UpdateRectanglePerimeterCommand, RectanglePerimeterResponse>
{
    private readonly IInfinBankDBContext _dbContext;
    private readonly ICustomLoggingBehavoir _customLoggingBehavior;
    private readonly ICalculateRectangleService _calculateRectangleService;
    private static readonly string _ClassName = nameof(UpdateRectanglePerimeterCommandHandler);

    public UpdateRectanglePerimeterCommandHandler(IInfinBankDBContext dbContext, ICustomLoggingBehavoir customLoggingBehavior, ICalculateRectangleService calculateRectangleService) => (_dbContext, _customLoggingBehavior, _calculateRectangleService) = (dbContext, customLoggingBehavior, calculateRectangleService);

    public async Task<RectanglePerimeterResponse> Handle(UpdateRectanglePerimeterCommand request, CancellationToken cancellationToken)
    {
        double perimeter = _calculateRectangleService.CalculatePerimeter(request.Width, request.Length);

        var rectangleEntity = await _dbContext.RectangleEntity.FirstOrDefaultAsync(rectangleEntity => rectangleEntity.Id == request.Id, cancellationToken);

        if (rectangleEntity == null)
        {
            throw new NotFoundException(nameof(RectangleEntity), request.Id);
        }

        rectangleEntity.Perimeter = perimeter;
        rectangleEntity.Length = request.Length;
        rectangleEntity.Width = request.Width;

        var result = await _dbContext.SaveChangesAsync(cancellationToken);
        if (result > 0)
        {
            _customLoggingBehavior.WriteToFileSuccess(_ClassName, rectangleEntity);
        }
        RectanglePerimeterResponse rectanglePerimeterResponse = new RectanglePerimeterResponse();
        rectanglePerimeterResponse.Perimeter = perimeter;
        rectanglePerimeterResponse.Width = request.Width;
        rectanglePerimeterResponse.Length = request.Length;
        rectanglePerimeterResponse.DateCreated = rectangleEntity.DateCreated;
        rectanglePerimeterResponse.DateUpdated = rectangleEntity.DateUpdated;
        return rectanglePerimeterResponse;
    }
}