using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using InfinBank.Application.Common.Exceptions;
using InfinBank.Application.Interfaces;
using InfinBank.Domain.Entities.Square;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace InfinBank.Application.CQRS.Queries.Squares.GetSquareAreaDetails;

public class GetSquareAreaDetailsQueryHandler : IRequestHandler<GetSquareAreaDetailsQuery, SquareAreaDetailsVm>
{
    private readonly IInfinBankDBContext _dbContext;
    private readonly IMapper _mapper;

    public GetSquareAreaDetailsQueryHandler(IInfinBankDBContext dbContext, IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

    public async Task<SquareAreaDetailsVm> Handle(GetSquareAreaDetailsQuery request, CancellationToken cancellationToken)
    {
        var squareEntity = await _dbContext.SquareEntity.FirstOrDefaultAsync(squareEntity => squareEntity.Id == request.Id, cancellationToken);

        if (squareEntity == null)
        {
            throw new NotFoundException(nameof(SquareEntity), request.Id);
        }
        return _mapper.Map<SquareAreaDetailsVm>(squareEntity);
    }
}
