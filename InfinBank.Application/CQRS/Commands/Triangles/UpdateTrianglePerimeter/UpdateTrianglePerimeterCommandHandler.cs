using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfinBank.Application.Common.Exceptions;
using InfinBank.Application.Interfaces;
using InfinBank.Application.Interfaces.ICalculateServices;
using InfinBank.Domain.Entities.Triangle;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace InfinBank.Application.CQRS.Commands.Triangles.UpdateTrianglePerimeter;

public class UpdateTrianglePerimeterCommandHandler : IRequestHandler<UpdateTrianglePerimeterCommand, TrianglePerimeterResponse>
{
    private readonly IInfinBankDBContext _dbContext;
    private readonly ICustomLoggingBehavoir _customLoggingBehavior;
    private readonly ICalculateTriangleService _calculateTriangleService;
    private static readonly string _ClassName = nameof(UpdateTrianglePerimeterCommandHandler);

    public UpdateTrianglePerimeterCommandHandler(IInfinBankDBContext dbContext, ICustomLoggingBehavoir customLoggingBehavior, ICalculateTriangleService calculateTriangleService) => (_dbContext, _customLoggingBehavior, _calculateTriangleService) = (dbContext, customLoggingBehavior, calculateTriangleService);

    public async Task<TrianglePerimeterResponse> Handle(UpdateTrianglePerimeterCommand request, CancellationToken cancellationToken)
    {
        double perimeter = _calculateTriangleService.CalculatePerimeter(request.ASide, request.BSide, request.CSide);

        var triangleEntity = await _dbContext.TriangleEntity.FirstOrDefaultAsync(triangleEntity => triangleEntity.Id == request.Id, cancellationToken);

        if (triangleEntity == null)
        {
            throw new NotFoundException(nameof(TriangleEntity), request.Id);
        }
        triangleEntity.ASide = request.ASide;
        triangleEntity.BSide = request.BSide;
        triangleEntity.CSide = request.CSide;
        triangleEntity.Perimeter = perimeter;

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
        trianglePerimeterResponse.DateCreated = triangleEntity.DateCreated;
        trianglePerimeterResponse.DateUpdated = triangleEntity.DateUpdated;
        return trianglePerimeterResponse;
    }
}

