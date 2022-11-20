using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace InfinBank.Application.CQRS.Queries.Rectangles.GetRectanglePerimeterDetails;

public class GetRectanglePerimeterDetailsQueryValidator : AbstractValidator<GetRectanglePerimeterDetailsQuery>
{
    public GetRectanglePerimeterDetailsQueryValidator()
    {
        RuleFor(getRectanglePerimeterDetailsQuery => getRectanglePerimeterDetailsQuery.Id).GreaterThan(0);
    }
}
