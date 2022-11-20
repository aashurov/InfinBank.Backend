using FluentValidation;

namespace InfinBank.Application.CQRS.Commands.Circles.UpdateCircleSquare;

public class UpdateCircleSquareValidator : AbstractValidator<UpdateCircleSquareCommand>
{
    public UpdateCircleSquareValidator()
    {
        RuleFor(updateCircleSquareCommand => updateCircleSquareCommand.Id).GreaterThan(0);
        RuleFor(updateCircleSquareCommand => updateCircleSquareCommand.Radius).NotEmpty();
    }
}