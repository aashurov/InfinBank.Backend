using InfinBank.Domain.Entities.Circle;
using MediatR;

namespace InfinBank.Application.CQRS.Commands.Circles.CreateCircleCircumference;

public class CreateCircleCircumferenceCommand : IRequest<CircleCircumferenceResponse>
{
    /// <summary>
    /// Radius of circle
    /// </summary>
    public double Radius { get; set; }
}