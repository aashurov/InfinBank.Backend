using MediatR;

namespace InfinBank.Application.CQRS.Commands.Squares.DeleteSquarePerimeter;

public class DeleteSquarePerimeterCommand : IRequest
{
    public int Id { get; set; }
}