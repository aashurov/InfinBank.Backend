using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfinBank.Application.Common.Exceptions;
using InfinBank.Application.Interfaces;
using InfinBank.Application.Interfaces.ICalculateServices;
using InfinBank.Domain.Entities.Square;
using InfinBank.Domain.Entities.Triangle;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace InfinBank.Application.CQRS.Commands.Triangles.UpdateTriangleArea;

public class UpdateTriangleAreaCommandHandler : IRequestHandler<UpdateTriangleAreaCommand, TriangleSquareResponse>
{
    private readonly IInfinBankDBContext _dbContext;
    private readonly ICustomLoggingBehavoir _customLoggingBehavior;
    private readonly ICalculateTriangleService _calculateTriangleService;
    private static readonly string _ClassName = nameof(UpdateTriangleAreaCommandHandler);

    public UpdateTriangleAreaCommandHandler(IInfinBankDBContext dbContext, ICustomLoggingBehavoir customLoggingBehavior, ICalculateTriangleService calculateTriangleService) => (_dbContext, _customLoggingBehavior, _calculateTriangleService) = (dbContext, customLoggingBehavior, calculateTriangleService);

    public async Task<TriangleSquareResponse> Handle(UpdateTriangleAreaCommand request, CancellationToken cancellationToken)
    {
        double area = _calculateTriangleService.CalculateSquare(request.ASide, request.BSide, request.CSide);

        var triangleEntity = await _dbContext.TriangleEntity.FirstOrDefaultAsync(triangleEntity => triangleEntity.Id == request.Id, cancellationToken);

        if (triangleEntity == null)
        {
            throw new NotFoundException(nameof(TriangleEntity), request.Id);
        }
        triangleEntity.ASide = request.ASide;
        triangleEntity.BSide = request.BSide;
        triangleEntity.CSide = request.CSide;
        triangleEntity.Square = area;

        var result = await _dbContext.SaveChangesAsync(cancellationToken);
        if (result > 0)
        {
            _customLoggingBehavior.WriteToFileSuccess(_ClassName, triangleEntity);
        }
        TriangleSquareResponse triangleSquareResponse = new TriangleSquareResponse();
        triangleSquareResponse.ASide = request.ASide;
        triangleSquareResponse.BSide = request.BSide;
        triangleSquareResponse.CSide = request.CSide;
        triangleSquareResponse.Square = area;
        triangleSquareResponse.DateCreated = triangleEntity.DateCreated;
        triangleSquareResponse.DateUpdated = triangleEntity.DateUpdated;
        return triangleSquareResponse;
    }
}
