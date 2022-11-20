using FluentValidation;

namespace InfinBank.Application.CQRS.Commands.Circles.UpdateCircleCircumference;

public class UpdateCircleCircumferenceValidator : AbstractValidator<UpdateCircleCircumferenceCommand>
{
    public UpdateCircleCircumferenceValidator()
    {
        RuleFor(updateCircleCircumferenceCommand => updateCircleCircumferenceCommand.Id).GreaterThan(0);
        RuleFor(updateCircleCircumferenceCommand => updateCircleCircumferenceCommand.Radius).NotEmpty();
    }
}