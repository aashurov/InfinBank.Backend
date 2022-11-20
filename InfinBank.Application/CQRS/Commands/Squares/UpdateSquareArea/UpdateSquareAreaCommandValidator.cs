using FluentValidation;

namespace InfinBank.Application.CQRS.Commands.Squares.UpdateSquareArea;

public class UpdateSquareAreaCommandValidator : AbstractValidator<UpdateSquareAreaCommand>
{
    public UpdateSquareAreaCommandValidator()
    {
        RuleFor(updateSquareAreaCommand => updateSquareAreaCommand.Id).GreaterThan(0);
        RuleFor(updateSquareAreaCommand => updateSquareAreaCommand.Side).NotEmpty();
    }
}