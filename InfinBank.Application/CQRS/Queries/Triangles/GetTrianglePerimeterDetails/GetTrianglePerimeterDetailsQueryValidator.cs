using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace InfinBank.Application.CQRS.Queries.Triangles.GetTrianglePerimeterDetails;

public class GetTrianglePerimeterDetailsQueryValidator : AbstractValidator<GetTrianglePerimeterDetailsQuery>
{
    public GetTrianglePerimeterDetailsQueryValidator()
    {
        RuleFor(getTrianglePerimeterDetailsQuery => getTrianglePerimeterDetailsQuery.Id).GreaterThan(0);
    }
}