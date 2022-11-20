using InfinBank.Domain.Entities.Square;
using MediatR;

namespace InfinBank.Application.CQRS.Commands.Squares.CreateSquareArea;

public class CreateSquareAreaCommand : IRequest<SquareAreaResponse>
{
    /// <summary>
    /// Side of square
    /// </summary>
    public double Side { get; set; }
}