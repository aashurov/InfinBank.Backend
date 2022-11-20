using FluentValidation;

namespace InfinBank.Application.CQRS.Commands.Squares.CreateSquarePerimeter;

public class CreateSquarePerimeterCommandValidator : AbstractValidator<CreateSquarePerimeterCommand>
{
    public CreateSquarePerimeterCommandValidator()
    {
        RuleFor(createSquarePerimeterCommand => createSquarePerimeterCommand.Side).NotNull();
    }
}