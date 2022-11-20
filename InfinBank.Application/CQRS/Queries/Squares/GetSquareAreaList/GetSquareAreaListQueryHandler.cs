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

namespace InfinBank.Application.CQRS.Queries.Squares.GetSquareAreaList;

public class GetSquareAreaListQueryHandler : IRequestHandler<GetSquareAreaListQuery, SquareAreaListVm>
{
    private readonly IInfinBankDBContext _dbContext;
    private readonly IMapper _mapper;

    public GetSquareAreaListQueryHandler(IInfinBankDBContext dbContext, IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

    public async Task<SquareAreaListVm> Handle(GetSquareAreaListQuery request, CancellationToken cancellationToken)
    {
        var squareEntity = await _dbContext.SquareEntity
            .ProjectTo<SquareAreaLookupDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
        return new SquareAreaListVm { SquareAreas = squareEntity };
    }
}