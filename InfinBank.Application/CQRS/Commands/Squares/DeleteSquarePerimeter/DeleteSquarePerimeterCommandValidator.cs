using FluentValidation;

namespace InfinBank.Application.CQRS.Commands.Squares.DeleteSquarePerimeter;

public class DeleteSquarePerimeterCommandValidator : AbstractValidator<DeleteSquarePerimeterCommand>
{
    public DeleteSquarePerimeterCommandValidator()
    {
        RuleFor(deleteSquarePerimeterCommand => deleteSquarePerimeterCommand.Id).GreaterThan(0);
    }
}