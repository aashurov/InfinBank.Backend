using InfinBank.Domain.Entities.Circle;
using MediatR;

namespace InfinBank.Application.CQRS.Commands.Circles.CreateCircleSquare;

public class CreateCircleSquareCommand : IRequest<CircleSquareResponse>
{
    /// <summary>
    /// Radius of circle
    /// </summary>
    public double Radius { get; set; }
}