using FluentValidation;

namespace InfinBank.Application.CQRS.Commands.Rectangles.DeleteRectangleSquare;

public class DeleteRectangleSquareCommandValidator : AbstractValidator<DeleteRectangleSquareCommand>
{
    public DeleteRectangleSquareCommandValidator()
    {
        RuleFor(deleteRectangleSquareCommand => deleteRectangleSquareCommand.Id).GreaterThan(0);
    }
}