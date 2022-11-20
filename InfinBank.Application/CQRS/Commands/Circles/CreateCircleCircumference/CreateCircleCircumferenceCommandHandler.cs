using InfinBank.Application.Interfaces;
using InfinBank.Application.Interfaces.ICalculateServices;
using InfinBank.Domain.Entities.Circle;
using MediatR;

namespace InfinBank.Application.CQRS.Commands.Circles.CreateCircleCircumference;

public class CreateCircleCircumferenceCommandHandler : IRequestHandler<CreateCircleCircumferenceCommand, CircleCircumferenceResponse>
{
    private readonly IInfinBankDBContext _dbContext;
    private readonly ICustomLoggingBehavoir _customLoggingBehavior;
    private readonly ICalculateCircleService _calculateCircleService;
    private readonly IDateTimeService _dateTimeService;

    private static readonly string _ClassName = nameof(CreateCircleCircumferenceCommandHandler);

    public CreateCircleCircumferenceCommandHandler(IInfinBankDBContext dbContext, ICustomLoggingBehavoir customLoggingBehavior, ICalculateCircleService calculateCircleService, IDateTimeService dateTimeService) => (_dbContext, _customLoggingBehavior, _calculateCircleService, _dateTimeService) = (dbContext, customLoggingBehavior, calculateCircleService, dateTimeService);

    public async Task<CircleCircumferenceResponse> Handle(CreateCircleCircumferenceCommand request, CancellationToken cancellationToken)
    {
        double circumference = _calculateCircleService.CalculateCircumference(request.Radius);
        var circleEntity = new CircleEntity
        {
            Circumference = circumference,
            Radius = request.Radius
        };
        await _dbContext.CircleEntity.AddAsync(circleEntity, cancellationToken);
        var result = await _dbContext.SaveChangesAsync(cancellationToken);
        if (result > 0)
        {
            _customLoggingBehavior.WriteToFileSuccess(_ClassName, circleEntity);
        }
        CircleCircumferenceResponse circleCircumferenceResponse = new CircleCircumferenceResponse();
        circleCircumferenceResponse.Radius = request.Radius;
        circleCircumferenceResponse.Circumference = circumference;
        circleCircumferenceResponse.DateCreated = _dateTimeService.Now;

        return circleCircumferenceResponse;
    }
}