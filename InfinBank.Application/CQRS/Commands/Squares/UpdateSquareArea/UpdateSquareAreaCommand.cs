using InfinBank.Domain.Entities.Square;
using MediatR;

namespace InfinBank.Application.CQRS.Commands.Squares.UpdateSquareArea;

public class UpdateSquareAreaCommand : IRequest<SquareAreaResponse>
{
    public int Id { get; set; }

    /// <summary>
    /// Side of square
    /// </summary>
    public double Side { get; set; }
}