using FluentValidation;

namespace InfinBank.Application.CQRS.Queries.Circles.GetlCircleCircumferenceDetails;

public class GetCircleCircumferenceDetailsQueryValidator : AbstractValidator<GetCircleCircumferenceDetailsQuery>
{
    public GetCircleCircumferenceDetailsQueryValidator()
    {
        RuleFor(getCircleCircumferenceDetailsQuery => getCircleCircumferenceDetailsQuery.Id).GreaterThan(0);
    }
}