using FluentValidation;

namespace InfinBank.Application.CQRS.Commands.Circles.CreateCircleSquare;

public class CreateCircleSquareValidator : AbstractValidator<CreateCircleSquareCommand>
{
    public CreateCircleSquareValidator()
    {
        RuleFor(createCircleSquareCommand => createCircleSquareCommand.Radius).NotNull();
    }
}