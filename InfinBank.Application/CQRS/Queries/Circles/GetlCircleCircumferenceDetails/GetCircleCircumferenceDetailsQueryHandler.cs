using AutoMapper;
using InfinBank.Application.Common.Exceptions;
using InfinBank.Application.Interfaces;
using InfinBank.Domain.Entities.Circle;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace InfinBank.Application.CQRS.Queries.Circles.GetlCircleCircumferenceDetails;

public class GetCircleCircumferenceDetailsQueryHandler : IRequestHandler<GetCircleCircumferenceDetailsQuery, CircleCircumferenceDetailsVm>
{
    private readonly IInfinBankDBContext _dbContext;
    private readonly IMapper _mapper;

    public GetCircleCircumferenceDetailsQueryHandler(IInfinBankDBContext dbContext, IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

    public async Task<CircleCircumferenceDetailsVm> Handle(GetCircleCircumferenceDetailsQuery request, CancellationToken cancellationToken)
    {
        var circleEntity = await _dbContext.CircleEntity.FirstOrDefaultAsync(circleEntity => circleEntity.Id == request.Id, cancellationToken);

        if (circleEntity == null)
        {
            throw new NotFoundException(nameof(CircleEntity), request.Id);
        }
        return _mapper.Map<CircleCircumferenceDetailsVm>(circleEntity);
    }
}