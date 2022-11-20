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

namespace InfinBank.Application.CQRS.Queries.Triangles.GetTriangleAreaDetails;

public class GetTriangleAreaDetailsQueryHandler : IRequestHandler<GetTriangleAreaDetailsQuery, TriangleAreaDetailsVm>
{
    private readonly IInfinBankDBContext _dbContext;
    private readonly IMapper _mapper;

    public GetTriangleAreaDetailsQueryHandler(IInfinBankDBContext dbContext, IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

    public async Task<TriangleAreaDetailsVm> Handle(GetTriangleAreaDetailsQuery request, CancellationToken cancellationToken)
    {
        var squareEntity = await _dbContext.TriangleEntity.FirstOrDefaultAsync(squareEntity => squareEntity.Id == request.Id, cancellationToken);

        if (squareEntity == null)
        {
            throw new NotFoundException(nameof(TriangleEntity), request.Id);
        }
        return _mapper.Map<TriangleAreaDetailsVm>(squareEntity);
    }
}

