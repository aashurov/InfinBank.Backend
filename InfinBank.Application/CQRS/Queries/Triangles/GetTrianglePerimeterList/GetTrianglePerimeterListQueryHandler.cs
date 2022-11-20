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

namespace InfinBank.Application.CQRS.Queries.Triangles.GetTrianglePerimeterList;

public class GetTrianglePerimeterListQueryHandler : IRequestHandler<GetTrianglePerimeterListQuery, TrianglePerimeterListVm>
{
    private readonly IInfinBankDBContext _dbContext;
    private readonly IMapper _mapper;

    public GetTrianglePerimeterListQueryHandler(IInfinBankDBContext dbContext, IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

    public async Task<TrianglePerimeterListVm> Handle(GetTrianglePerimeterListQuery request, CancellationToken cancellationToken)
    {
        var triangleEntity = await _dbContext.TriangleEntity
            .ProjectTo<TrianglePerimeterLookupDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
        return new TrianglePerimeterListVm { TrianglePerimetres = triangleEntity };
    }
}