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

namespace InfinBank.Application.CQRS.Queries.Rectangles.GetRectanglePerimeterList;

public class GetRectanglePerimeterListQueryHandler : IRequestHandler<GetRectanglePerimeterListQuery, RectanglePerimeterListVm>
{
    private readonly IInfinBankDBContext _dbContext;
    private readonly IMapper _mapper;

    public GetRectanglePerimeterListQueryHandler(IInfinBankDBContext dbContext, IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

    public async Task<RectanglePerimeterListVm> Handle(GetRectanglePerimeterListQuery request, CancellationToken cancellationToken)
    {
        var getRectanglePerimeterListQuery = await _dbContext.RectangleEntity
            .ProjectTo<RectanglePerimeterLookupDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
        return new RectanglePerimeterListVm {  RectanglePerimeteres = getRectanglePerimeterListQuery };
    }
}