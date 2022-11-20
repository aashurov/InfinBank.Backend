using FluentValidation;

namespace InfinBank.Application.CQRS.Commands.Squares.CreateSquareArea;

public class CreateSquareAreaCommandValidator : AbstractValidator<CreateSquareAreaCommand>
{
    public CreateSquareAreaCommandValidator()
    {
        RuleFor(createSquareAreaCommand => createSquareAreaCommand.Side).NotNull();
    }
}