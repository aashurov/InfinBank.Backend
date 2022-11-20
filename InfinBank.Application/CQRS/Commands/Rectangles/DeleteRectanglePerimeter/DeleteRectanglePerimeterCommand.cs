using MediatR;

namespace InfinBank.Application.CQRS.Commands.Rectangles.DeleteRectanglePerimeter;

public class DeleteRectanglePerimeterCommand : IRequest
{
    public int Id { get; set; }
}