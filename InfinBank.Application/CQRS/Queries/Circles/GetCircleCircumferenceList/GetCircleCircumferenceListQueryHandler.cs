using AutoMapper;
using AutoMapper.QueryableExtensions;
using InfinBank.Application.CQRS.Queries.Circles.GetCircleCircumferenceList;
using InfinBank.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace InfinBank.Application.CQRS.Queries.Circles.CreateCircleCircumference;

public class GetCircleCircumferenceListQueryHandler : IRequestHandler<GetCircleCircumferenceListQuery, CircleCircumferenceListVm>
{
    private readonly IInfinBankDBContext _dbContext;
    private readonly IMapper _mapper;

    public GetCircleCircumferenceListQueryHandler(IInfinBankDBContext dbContext, IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

    public async Task<CircleCircumferenceListVm> Handle(GetCircleCircumferenceListQuery request, CancellationToken cancellationToken)
    {
        var circleCircumferencesQuery = await _dbContext.CircleEntity
            .ProjectTo<CircleCircumferenceLookupDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
        return new CircleCircumferenceListVm { CircleCircumferences = circleCircumferencesQuery };
    }
}