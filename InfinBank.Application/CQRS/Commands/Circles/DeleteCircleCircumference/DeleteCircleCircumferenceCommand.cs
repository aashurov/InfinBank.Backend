using MediatR;

namespace InfinBank.Application.CQRS.Commands.Circles.DeleteCircleCircumference;

public class DeleteCircleCircumferenceCommand : IRequest
{
    public int Id { get; set; }
}