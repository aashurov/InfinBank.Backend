using InfinBank.Domain.Entities.Square;
using MediatR;

namespace InfinBank.Application.CQRS.Commands.Squares.UpdateSquarePerimeter;

public class UpdateSquarePerimeterCommand : IRequest<SquarePerimeterResponse>
{
    public int Id { get; set; }

    /// <summary>
    /// Side of square
    /// </summary>
    public double Side { get; set; }
}