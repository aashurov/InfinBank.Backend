using InfinBank.Application.Common.Exceptions;
using InfinBank.Application.Interfaces;
using InfinBank.Application.Interfaces.ICalculateServices;
using InfinBank.Domain.Entities.Square;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace InfinBank.Application.CQRS.Commands.Squares.UpdateSquarePerimeter;

public class UpdateSquarePerimeterCommandHandler : IRequestHandler<UpdateSquarePerimeterCommand, SquarePerimeterResponse>
{
    private readonly IInfinBankDBContext _dbContext;
    private readonly ICustomLoggingBehavoir _customLoggingBehavior;
    private readonly ICalculateSquareService _calculateSquareService;
    private static readonly string _ClassName = nameof(UpdateSquarePerimeterCommandHandler);

    public UpdateSquarePerimeterCommandHandler(IInfinBankDBContext dbContext, ICustomLoggingBehavoir customLoggingBehavior, ICalculateSquareService calculateSquareService) => (_dbContext, _customLoggingBehavior, _calculateSquareService) = (dbContext, customLoggingBehavior, calculateSquareService);

    public async Task<SquarePerimeterResponse> Handle(UpdateSquarePerimeterCommand request, CancellationToken cancellationToken)
    {
        double perimeter = _calculateSquareService.CalculatePerimeter(request.Side);

        var perimeterEntity = await _dbContext.SquareEntity.FirstOrDefaultAsync(areaEntity => areaEntity.Id == request.Id, cancellationToken);

        if (perimeterEntity == null)
        {
            throw new NotFoundException(nameof(SquareEntity), request.Id);
        }

        perimeterEntity.Perimeter = perimeter;
        perimeterEntity.Side = request.Side;

        var result = await _dbContext.SaveChangesAsync(cancellationToken);
        if (result > 0)
        {
            _customLoggingBehavior.WriteToFileSuccess(_ClassName, perimeterEntity);
        }
        SquarePerimeterResponse squarePerimeterResponse = new SquarePerimeterResponse();
        squarePerimeterResponse.Perimeter = perimeter;
        squarePerimeterResponse.Side = request.Side;
        squarePerimeterResponse.DateCreated = perimeterEntity.DateCreated;
        squarePerimeterResponse.DateUpdated = perimeterEntity.DateUpdated;

        return squarePerimeterResponse;
     }
}