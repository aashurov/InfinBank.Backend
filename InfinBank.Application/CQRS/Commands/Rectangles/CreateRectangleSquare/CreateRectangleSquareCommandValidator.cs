using FluentValidation;

namespace InfinBank.Application.CQRS.Commands.Rectangles.CreateRectangleSquare;

public class CreateRectangleSquareCommandValidator : AbstractValidator<CreateRectangleSquareCommand>
{
    public CreateRectangleSquareCommandValidator()
    {
        RuleFor(createRectangleSquareCommand => createRectangleSquareCommand.Length).NotNull();
        RuleFor(createRectangleSquareCommand => createRectangleSquareCommand.Width).NotNull();
    }
}