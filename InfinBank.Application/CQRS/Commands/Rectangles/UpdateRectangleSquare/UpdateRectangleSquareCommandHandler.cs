using InfinBank.Application.Common.Exceptions;
using InfinBank.Application.CQRS.Commands.Rectangles.UpdateRectanglePerimeter;
using InfinBank.Application.Interfaces;
using InfinBank.Application.Interfaces.ICalculateServices;
using InfinBank.Domain.Entities.Rectangle;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace InfinBank.Application.CQRS.Commands.Rectangles.UpdateRectangleSquare;

public class UpdateRectangleSquareCommandHandler : IRequestHandler<UpdateRectangleSquareCommand, RectangleSquareResponse>
{
    private readonly IInfinBankDBContext _dbContext;
    private readonly ICustomLoggingBehavoir _customLoggingBehavior;
    private readonly ICalculateRectangleService _calculateRectangleService;
    private static readonly string _ClassName = nameof(UpdateRectanglePerimeterCommandHandler);

    public UpdateRectangleSquareCommandHandler(IInfinBankDBContext dbContext, ICustomLoggingBehavoir customLoggingBehavior, ICalculateRectangleService calculateRectangleService) => (_dbContext, _customLoggingBehavior, _calculateRectangleService) = (dbContext, customLoggingBehavior, calculateRectangleService);

    public async Task<RectangleSquareResponse> Handle(UpdateRectangleSquareCommand request, CancellationToken cancellationToken)
    {
        double square = _calculateRectangleService.CalculateSquare(request.Width, request.Length);

        var rectangleEntity = await _dbContext.RectangleEntity.FirstOrDefaultAsync(rectangleEntity => rectangleEntity.Id == request.Id, cancellationToken);

        if (rectangleEntity == null)
        {
            throw new NotFoundException(nameof(RectangleEntity), request.Id);
        }

        rectangleEntity.Square = square;
        rectangleEntity.Length = request.Length;
        rectangleEntity.Width = request.Width;

        var result = await _dbContext.SaveChangesAsync(cancellationToken);
        if (result > 0)
        {
            _customLoggingBehavior.WriteToFileSuccess(_ClassName, rectangleEntity);
        }
        RectangleSquareResponse rectangleSquareResponse = new RectangleSquareResponse();
        rectangleSquareResponse.Square = square;
        rectangleSquareResponse.Width = request.Width;
        rectangleSquareResponse.Length = request.Length;
        rectangleSquareResponse.DateCreated = rectangleEntity.DateCreated;
        rectangleSquareResponse.DateUpdated = rectangleEntity.DateUpdated;
        return rectangleSquareResponse;
    }
}