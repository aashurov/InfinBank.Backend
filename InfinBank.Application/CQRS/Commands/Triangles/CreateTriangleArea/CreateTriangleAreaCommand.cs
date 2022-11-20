using InfinBank.Domain.Entities.Triangle;
using MediatR;

namespace InfinBank.Application.CQRS.Commands.Triangles.CreateTriangleArea;

public class CreateTriangleAreaCommand : IRequest<TriangleSquareResponse>
{
    /// <summary>
    /// A side of triangle
    /// </summary>
    public double ASide { get; set; }

    /// <summary>
    /// B side of triangle
    /// </summary>
    public double BSide { get; set; }

    /// <summary>
    /// C side of triangle
    /// </summary>
    public double CSide { get; set; }
}