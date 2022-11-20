using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using InfinBank.Application.CQRS.Queries.Rectangles.GetRectangleSquareDetails;

namespace InfinBank.Application.CQRS.Queries.Rectangles.GetRectangleSquareDetails;

public class GetRectangleSquareDetailsQueryValidator : AbstractValidator<GetRectangleSquareDetailsQuery>
{
    public GetRectangleSquareDetailsQueryValidator()
    {
        RuleFor(getRectangleSquareDetailsQuery => getRectangleSquareDetailsQuery.Id).GreaterThan(0);
    }
}
