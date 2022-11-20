using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace InfinBank.Application.CQRS.Queries.Triangles.GetTriangleAreaDetails;

public class GetTriangleAreaDetailsQueryValidator : AbstractValidator<GetTriangleAreaDetailsQuery>
{
    public GetTriangleAreaDetailsQueryValidator()
    {
        RuleFor(getTriangleAreaDetailsQuery => getTriangleAreaDetailsQuery.Id).GreaterThan(0);
    }
}