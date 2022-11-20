using FluentValidation;

namespace InfinBank.Application.CQRS.Queries.Circles.GetCircleSquareList;

public class GetCircleSquareListQueryValidator : AbstractValidator<GetCircleSquareListQuery>
{
    public GetCircleSquareListQueryValidator()
    {
    }
}