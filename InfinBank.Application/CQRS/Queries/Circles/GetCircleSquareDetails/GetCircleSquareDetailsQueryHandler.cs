using AutoMapper;
using InfinBank.Application.Common.Exceptions;
using InfinBank.Application.Interfaces;
using InfinBank.Domain.Entities.Circle;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace InfinBank.Application.CQRS.Queries.Circles.GetCircleSquareDetails;

public class GetCircleSquareDetailsQueryHandler : IRequestHandler<GetCircleSquareDetailsQuery, CircleSquareDetailsVm>
{
    private readonly IInfinBankDBContext _dbContext;
    private readonly IMapper _mapper;

    public GetCircleSquareDetailsQueryHandler(IInfinBankDBContext dbContext, IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

    public async Task<CircleSquareDetailsVm> Handle(GetCircleSquareDetailsQuery request, CancellationToken cancellationToken)
    {
        var circleEntity = await _dbContext.CircleEntity.FirstOrDefaultAsync(circleEntity => circleEntity.Id == request.Id, cancellationToken);

        if (circleEntity == null)
        {
            throw new NotFoundException(nameof(CircleEntity), request.Id);
        }
        return _mapper.Map<CircleSquareDetailsVm>(circleEntity);
    }
}