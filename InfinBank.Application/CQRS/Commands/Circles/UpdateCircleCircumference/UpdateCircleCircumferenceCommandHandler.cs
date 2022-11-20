using InfinBank.Application.Common.Exceptions;
using InfinBank.Application.Interfaces;
using InfinBank.Application.Interfaces.ICalculateServices;
using InfinBank.Domain.Entities.Circle;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace InfinBank.Application.CQRS.Commands.Circles.UpdateCircleCircumference;

public class UpdateCircleCircumferenceCommandHandler : IRequestHandler<UpdateCircleCircumferenceCommand, CircleCircumferenceResponse>
{
    private readonly IInfinBankDBContext _dbContext;
    private readonly ICustomLoggingBehavoir _customLoggingBehavior;
    private readonly ICalculateCircleService _calculateCircleService;
    private readonly IDateTimeService _dateTimeService;
    private static readonly string _ClassName = nameof(UpdateCircleCircumferenceCommandHandler);

    public UpdateCircleCircumferenceCommandHandler(IInfinBankDBContext dbContext, ICustomLoggingBehavoir customLoggingBehavior, ICalculateCircleService calculateCircleService, IDateTimeService dateTimeService) => (_dbContext, _customLoggingBehavior, _calculateCircleService, _dateTimeService) = (dbContext, customLoggingBehavior, calculateCircleService, dateTimeService);

    public async Task<CircleCircumferenceResponse> Handle(UpdateCircleCircumferenceCommand request, CancellationToken cancellationToken)
    {
        double circumference = _calculateCircleService.CalculateCircumference(request.Radius);

        var circleEntity = await _dbContext.CircleEntity.FirstOrDefaultAsync(circleEntity => circleEntity.Id == request.Id, cancellationToken);

        if (circleEntity == null)
        {
            throw new NotFoundException(nameof(CircleEntity), request.Id);
        }

        circleEntity.Circumference = circumference;
        circleEntity.Radius = request.Radius;

        var result = await _dbContext.SaveChangesAsync(cancellationToken);
        if (result > 0)
        {
            _customLoggingBehavior.WriteToFileSuccess(_ClassName, circleEntity);
        }

        CircleCircumferenceResponse circleCircumferenceResponse = new CircleCircumferenceResponse();
        circleCircumferenceResponse.Circumference = circumference;
        circleCircumferenceResponse.Radius = request.Radius;
        circleCircumferenceResponse.DateCreated = circleEntity.DateCreated;
        circleCircumferenceResponse.DateUpdated = circleEntity.DateUpdated;

        return circleCircumferenceResponse;
    }
}