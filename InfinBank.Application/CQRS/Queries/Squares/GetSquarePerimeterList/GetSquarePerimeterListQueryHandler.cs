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

namespace InfinBank.Application.CQRS.Queries.Squares.GetSquarePerimeterList;

public class GetSquareAreaListQueryHandler : IRequestHandler<GetSquarePerimeterListQuery, SquarePerimeterListVm>
{
    private readonly IInfinBankDBContext _dbContext;
    private readonly IMapper _mapper;

    public GetSquareAreaListQueryHandler(IInfinBankDBContext dbContext, IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

    public async Task<SquarePerimeterListVm> Handle(GetSquarePerimeterListQuery request, CancellationToken cancellationToken)
    {
        var squareEntity = await _dbContext.SquareEntity
            .ProjectTo<SquarePerimeterLookupDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
        return new SquarePerimeterListVm { SquarePerimetres = squareEntity };
    }
}