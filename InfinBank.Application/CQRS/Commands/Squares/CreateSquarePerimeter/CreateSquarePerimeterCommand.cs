using InfinBank.Domain.Entities.Square;
using MediatR;

namespace InfinBank.Application.CQRS.Commands.Squares.CreateSquarePerimeter;

public class CreateSquarePerimeterCommand : IRequest<SquarePerimeterResponse>
{
    /// <summary>
    /// Side of square
    /// </summary>
    public double Side { get; set; }
}