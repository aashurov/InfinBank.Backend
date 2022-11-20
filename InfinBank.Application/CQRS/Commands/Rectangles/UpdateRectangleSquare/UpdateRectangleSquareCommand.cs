using InfinBank.Domain.Entities.Rectangle;
using MediatR;

namespace InfinBank.Application.CQRS.Commands.Rectangles.UpdateRectangleSquare;

public class UpdateRectangleSquareCommand : IRequest<RectangleSquareResponse>
{
    public int Id { get; set; }

    /// <summary>
    /// Length of rectangle
    /// </summary>
    public double Length { get; set; }

    /// <summary>
    /// Width of rectangle
    /// </summary>
    public double Width { get; set; }
}