using InfinBank.Application.Common.Exceptions;
using InfinBank.Application.CQRS.Commands.Rectangles.UpdateRectanglePerimeter;
using InfinBank.Application.Interfaces;
using InfinBank.Application.Interfaces.ICalculateServices;
using InfinBank.Domain.Entities.Rectangle;
using InfinBank.Domain.Entities.Square;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace InfinBank.Application.CQRS.Commands.Squares.UpdateSquareArea;

public class UpdateSquareAreaCommandHandler : IRequestHandler<UpdateSquareAreaCommand, SquareAreaResponse>
{
    private readonly IInfinBankDBContext _dbContext;
    private readonly ICustomLoggingBehavoir _customLoggingBehavior;
    private readonly ICalculateSquareService _calculateSquareService;
    private static readonly string _ClassName = nameof(UpdateRectanglePerimeterCommandHandler);

    public UpdateSquareAreaCommandHandler(IInfinBankDBContext dbContext, ICustomLoggingBehavoir customLoggingBehavior, ICalculateSquareService calculateSquareService) => (_dbContext, _customLoggingBehavior, _calculateSquareService) = (dbContext, customLoggingBehavior, calculateSquareService);

    public async Task<SquareAreaResponse> Handle(UpdateSquareAreaCommand request, CancellationToken cancellationToken)
    {
        double area = _calculateSquareService.CalculateSquare(request.Side);

        var areaEntity = await _dbContext.SquareEntity.FirstOrDefaultAsync(areaEntity => areaEntity.Id == request.Id, cancellationToken);

        if (areaEntity == null)
        {
            throw new NotFoundException(nameof(SquareEntity), request.Id);
        }

        areaEntity.Area = area;
        areaEntity.Side = request.Side;

        var result = await _dbContext.SaveChangesAsync(cancellationToken);
        if (result > 0)
        {
            _customLoggingBehavior.WriteToFileSuccess(_ClassName, areaEntity);
        }
        SquareAreaResponse squareAreaResponse = new SquareAreaResponse();
        squareAreaResponse.Area = area;
        squareAreaResponse.Side = request.Side;
        squareAreaResponse.DateCreated = areaEntity.DateCreated;
        squareAreaResponse.DateUpdated = areaEntity.DateUpdated;

        return squareAreaResponse;
    }
}