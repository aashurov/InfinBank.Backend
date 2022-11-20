using FluentValidation;

namespace InfinBank.Application.CQRS.Commands.Squares.UpdateSquarePerimeter;

public class UpdateSquarePerimeterCommandValidator : AbstractValidator<UpdateSquarePerimeterCommand>
{
    public UpdateSquarePerimeterCommandValidator()
    {
        RuleFor(updateSquarePerimeterCommand => updateSquarePerimeterCommand.Id).GreaterThan(0);
        RuleFor(updateSquarePerimeterCommand => updateSquarePerimeterCommand.Side).NotEmpty();
    }
}