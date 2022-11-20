using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using InfinBank.Application.Common.Exceptions;
 using InfinBank.Application.Interfaces;
using InfinBank.Domain.Entities.Triangle;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace InfinBank.Application.CQRS.Queries.Triangles.GetTrianglePerimeterDetails;

public class GetTrianglePerimeterDetailsQueryHandler : IRequestHandler<GetTrianglePerimeterDetailsQuery, TrianglePerimeterDetailsVm>
{
    private readonly IInfinBankDBContext _dbContext;
    private readonly IMapper _mapper;

    public GetTrianglePerimeterDetailsQueryHandler(IInfinBankDBContext dbContext, IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

    public async Task<TrianglePerimeterDetailsVm> Handle(GetTrianglePerimeterDetailsQuery request, CancellationToken cancellationToken)
    {
        var triangleEntity = await _dbContext.TriangleEntity.FirstOrDefaultAsync(triangleEntity => triangleEntity.Id == request.Id, cancellationToken);

        if (triangleEntity == null)
        {
            throw new NotFoundException(nameof(TriangleEntity), request.Id);
        }
        return _mapper.Map<TrianglePerimeterDetailsVm>(triangleEntity);
    }
}

