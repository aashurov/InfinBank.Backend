using MediatR;

namespace InfinBank.Application.CQRS.Commands.Circles.DeleteCircleSquare;

public class DeleteCircleSquareCommand : IRequest
{
    public int Id { get; set; }
}