using FluentValidation;
using InfinBank.Application.CQRS.Commands.Rectangles.UpdateRectanglePerimeter;

namespace InfinBank.Application.CQRS.Commands.Rectangles.UpdateRectangleSquare;

public class UpdateRectangleSquareCommandValidator : AbstractValidator<UpdateRectanglePerimeterCommand>
{
    public UpdateRectangleSquareCommandValidator()
    {
        RuleFor(updateRectanglePerimeterCommand => updateRectanglePerimeterCommand.Id).GreaterThan(0);
        RuleFor(updateRectanglePerimeterCommand => updateRectanglePerimeterCommand.Length).NotEmpty();
        RuleFor(updateRectanglePerimeterCommand => updateRectanglePerimeterCommand.Width).NotEmpty();
    }
}