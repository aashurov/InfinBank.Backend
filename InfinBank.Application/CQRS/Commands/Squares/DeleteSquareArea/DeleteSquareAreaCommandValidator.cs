using FluentValidation;

namespace InfinBank.Application.CQRS.Commands.Squares.DeleteSquareArea;

public class DeleteSquareAreaCommandValidator : AbstractValidator<DeleteSquareAreaCommand>
{
    public DeleteSquareAreaCommandValidator()
    {
        RuleFor(deleteSquareAreaCommand => deleteSquareAreaCommand.Id).GreaterThan(0);
    }
}