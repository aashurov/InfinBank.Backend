using FluentValidation;

namespace InfinBank.Application.CQRS.Queries.Circles.GetCircleSquareDetails;

public class GetCircleSquareDetailsQueryValidator : AbstractValidator<GetCircleSquareDetailsQuery>
{
    public GetCircleSquareDetailsQueryValidator()
    {
        RuleFor(getCircleSquareDetailsQuery => getCircleSquareDetailsQuery.Id).GreaterThan(0);
    }
}