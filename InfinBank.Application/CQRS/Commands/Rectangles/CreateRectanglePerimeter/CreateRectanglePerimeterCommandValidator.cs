using FluentValidation;

namespace InfinBank.Application.CQRS.Commands.Rectangles.CreateRectanglePerimeter;

public class CreateRectanglePerimeterCommandValidator : AbstractValidator<CreateRectanglePerimeterCommand>
{
    public CreateRectanglePerimeterCommandValidator()
    {
        RuleFor(createRectanglePerimeterCommand => createRectanglePerimeterCommand.Length).NotNull();
        RuleFor(createRectanglePerimeterCommand => createRectanglePerimeterCommand.Width).NotNull();
    }
}