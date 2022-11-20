using FluentValidation;

namespace InfinBank.Application.CQRS.Commands.Rectangles.DeleteRectanglePerimeter;

public class DeleteRectanglePerimeterCommandValidator : AbstractValidator<DeleteRectanglePerimeterCommand>
{
    public DeleteRectanglePerimeterCommandValidator()
    {
        RuleFor(deleteRectanglePerimeterCommand => deleteRectanglePerimeterCommand.Id).GreaterThan(0);
    }
}