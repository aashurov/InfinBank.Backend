using InfinBank.Domain.Entities.Rectangle;
using MediatR;

namespace InfinBank.Application.CQRS.Commands.Rectangles.CreateRectangleSquare;

public class CreateRectangleSquareCommand : IRequest<RectangleSquareResponse>
{
    /// <summary>
    /// Length of rectangle
    /// </summary>
    public double Length { get; set; }

    /// <summary>
    /// Width of rectangle
    /// </summary>
    public double Width { get; set; }
}