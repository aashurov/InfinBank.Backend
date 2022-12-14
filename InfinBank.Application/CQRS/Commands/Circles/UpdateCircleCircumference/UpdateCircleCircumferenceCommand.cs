using InfinBank.Domain.Entities.Circle;
using MediatR;

namespace InfinBank.Application.CQRS.Commands.Circles.UpdateCircleCircumference;

public class UpdateCircleCircumferenceCommand : IRequest<CircleCircumferenceResponse>
{
    public int Id { get; set; }

    /// <summary>
    /// Radius of circle
    /// </summary>
    public double Radius { get; set; }
}