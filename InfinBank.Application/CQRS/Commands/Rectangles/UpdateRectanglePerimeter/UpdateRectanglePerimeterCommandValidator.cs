using FluentValidation;

namespace InfinBank.Application.CQRS.Commands.Rectangles.UpdateRectanglePerimeter;

public class UpdateRectanglePerimeterCommandValidator : AbstractValidator<UpdateRectanglePerimeterCommand>
{
    public UpdateRectanglePerimeterCommandValidator()
    {
        RuleFor(updateRectanglePerimeterCommand => updateRectanglePerimeterCommand.Id).GreaterThan(0);
        RuleFor(updateRectanglePerimeterCommand => updateRectanglePerimeterCommand.Length).NotEmpty();
        RuleFor(updateRectanglePerimeterCommand => updateRectanglePerimeterCommand.Width).NotEmpty();
    }
}