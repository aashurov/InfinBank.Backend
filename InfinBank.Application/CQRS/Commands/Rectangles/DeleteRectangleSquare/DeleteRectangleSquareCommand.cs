using MediatR;

namespace InfinBank.Application.CQRS.Commands.Rectangles.DeleteRectangleSquare;

public class DeleteRectangleSquareCommand : IRequest
{
    public int Id { get; set; }
}