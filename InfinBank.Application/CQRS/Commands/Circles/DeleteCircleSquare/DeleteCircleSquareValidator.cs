using FluentValidation;

namespace InfinBank.Application.CQRS.Commands.Circles.DeleteCircleSquare;

public class DeleteCircleSquareValidator : AbstractValidator<DeleteCircleSquareCommand>
{
    public DeleteCircleSquareValidator()
    {
        RuleFor(deleteCircleSquareCommand => deleteCircleSquareCommand.Id).GreaterThan(0);
    }
}