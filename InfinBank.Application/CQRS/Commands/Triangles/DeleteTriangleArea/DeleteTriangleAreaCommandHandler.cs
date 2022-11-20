using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfinBank.Application.Common.Exceptions;
using InfinBank.Application.CQRS.Commands.Squares.DeleteSquareArea;
using InfinBank.Application.Interfaces;
using InfinBank.Domain.Entities.Square;
using InfinBank.Domain.Entities.Triangle;
using MediatR;

namespace InfinBank.Application.CQRS.Commands.Triangles.DeleteTriangleArea;

public class DeleteTriangleAreaCommandHandler : IRequestHandler<DeleteTriangleAreaCommand>
{
    private readonly IInfinBankDBContext _dbContext;
    private readonly ICustomLoggingBehavoir _customLoggingBehavior;
    private static readonly string _ClassName = nameof(DeleteTriangleAreaCommandHandler);

    public DeleteTriangleAreaCommandHandler(IInfinBankDBContext dbContext, ICustomLoggingBehavoir customLoggingBehavior) => (_dbContext, _customLoggingBehavior) = (dbContext, customLoggingBehavior);

    public async Task<Unit> Handle(DeleteTriangleAreaCommand request, CancellationToken cancellationToken)
    {
        var triangleEntity = await _dbContext.TriangleEntity.FindAsync(new object[] { request.Id }, cancellationToken);

        if (triangleEntity == null)
        {
            throw new NotFoundException(nameof(TriangleEntity), request.Id);
        }
        _dbContext.TriangleEntity.Remove(triangleEntity);
        var result = await _dbContext.SaveChangesAsync(cancellationToken);

        if (result > 0)
        {
            _customLoggingBehavior.WriteToFileSuccess(_ClassName, triangleEntity);
        }
        return Unit.Value;
    }
}