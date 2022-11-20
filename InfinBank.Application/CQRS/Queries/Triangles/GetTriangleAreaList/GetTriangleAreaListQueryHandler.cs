using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using InfinBank.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace InfinBank.Application.CQRS.Queries.Triangles.GetTriangleAreaList;

public class GetTriangleAreaListQueryHandler : IRequestHandler<GetTriangleAreaListQuery, TriangleAreaListVm>
{
    private readonly IInfinBankDBContext _dbContext;
    private readonly IMapper _mapper;

    public GetTriangleAreaListQueryHandler(IInfinBankDBContext dbContext, IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

    public async Task<TriangleAreaListVm> Handle(GetTriangleAreaListQuery request, CancellationToken cancellationToken)
    {
        var triangleEntity = await _dbContext.TriangleEntity
            .ProjectTo<TriangleAreaLookupDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
        return new TriangleAreaListVm { TriangleAreas = triangleEntity };
    }
}