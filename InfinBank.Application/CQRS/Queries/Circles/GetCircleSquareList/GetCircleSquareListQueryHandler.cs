using AutoMapper;
using AutoMapper.QueryableExtensions;
using InfinBank.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace InfinBank.Application.CQRS.Queries.Circles.GetCircleSquareList;

public class GetCircleSquareListQueryHandler : IRequestHandler<GetCircleSquareListQuery, CircleSquareListVm>
{
    private readonly IInfinBankDBContext _dbContext;
    private readonly IMapper _mapper;

    public GetCircleSquareListQueryHandler(IInfinBankDBContext dbContext, IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

    public async Task<CircleSquareListVm> Handle(GetCircleSquareListQuery request, CancellationToken cancellationToken)
    {
        var circleSquareQuery = await _dbContext.CircleEntity
            .ProjectTo<CircleSquareLookupDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
        return new CircleSquareListVm { CircleSquares = circleSquareQuery };
    }
}