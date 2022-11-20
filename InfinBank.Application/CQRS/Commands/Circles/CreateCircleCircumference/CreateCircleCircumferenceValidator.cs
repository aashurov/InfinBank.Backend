using FluentValidation;

namespace InfinBank.Application.CQRS.Commands.Circles.CreateCircleCircumference;

public class CreateCircleCircumferenceValidator : AbstractValidator<CreateCircleCircumferenceCommand>
{
    public CreateCircleCircumferenceValidator()
    {
        RuleFor(createCircleCircumferenceCommand => createCircleCircumferenceCommand.Radius).NotNull();
    }
}