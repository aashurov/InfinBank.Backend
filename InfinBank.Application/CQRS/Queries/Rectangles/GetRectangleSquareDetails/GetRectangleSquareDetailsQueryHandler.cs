using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using InfinBank.Application.Common.Exceptions;
using InfinBank.Application.Interfaces;
using InfinBank.Domain.Entities.Rectangle;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace InfinBank.Application.CQRS.Queries.Rectangles.GetRectangleSquareDetails;

    public class GetRectanglePerimeterDetailsQueryHandler : IRequestHandler<GetRectangleSquareDetailsQuery, RectangleSquareDetailsVm>
{
    private readonly IInfinBankDBContext _dbContext;
    private readonly IMapper _mapper;

    public GetRectanglePerimeterDetailsQueryHandler(IInfinBankDBContext dbContext, IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

    public async Task<RectangleSquareDetailsVm> Handle(GetRectangleSquareDetailsQuery request, CancellationToken cancellationToken)
    {
        var rectangleEntity = await _dbContext.RectangleEntity.FirstOrDefaultAsync(rectangleEntity => rectangleEntity.Id == request.Id, cancellationToken);

        if (rectangleEntity == null)
        {
            throw new NotFoundException(nameof(RectangleEntity), request.Id);
        }
        return _mapper.Map<RectangleSquareDetailsVm>(rectangleEntity);
    }
}
