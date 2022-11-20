using InfinBank.Domain.Entities.Circle;
using MediatR;

namespace InfinBank.Application.CQRS.Commands.Circles.UpdateCircleSquare;

public class UpdateCircleSquareCommand : IRequest<CircleSquareResponse>
{
    public int Id { get; set; }

    /// <summary>
    /// Radius of circle
    /// </summary>
    public double Radius { get; set; }
}