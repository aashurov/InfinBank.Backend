using FluentValidation;

namespace InfinBank.Application.CQRS.Commands.Circles.DeleteCircleCircumference;

public class DeleteCircleCircumferenceValidator : AbstractValidator<DeleteCircleCircumferenceCommand>
{
    public DeleteCircleCircumferenceValidator()
    {
        RuleFor(deleteCircleCircumferenceCommand => deleteCircleCircumferenceCommand.Id).GreaterThan(0);
    }
}