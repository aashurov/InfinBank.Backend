using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using InfinBank.Application.CQRS.Queries.Rectangles.GetRectanglePerimeterList;
using InfinBank.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace InfinBank.Application.CQRS.Queries.Rectangles.GetRectangleSquareList;

public class GetRectangleSquareListQueryHandler : IRequestHandler<GetRectangleSquareListQuery, RectangleSquareListVm>
{
    private readonly IInfinBankDBContext _dbContext;
    private readonly IMapper _mapper;

    public GetRectangleSquareListQueryHandler(IInfinBankDBContext dbContext, IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

    public async Task<RectangleSquareListVm> Handle(GetRectangleSquareListQuery request, CancellationToken cancellationToken)
    {
        var getRectangleSquareListQuery = await _dbContext.RectangleEntity
            .ProjectTo<RectangleSquareLookupDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
        return new RectangleSquareListVm { RectangleSquares = getRectangleSquareListQuery };
    }
}