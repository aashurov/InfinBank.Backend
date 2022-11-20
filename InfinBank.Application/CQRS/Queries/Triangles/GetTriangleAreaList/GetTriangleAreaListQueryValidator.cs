using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace InfinBank.Application.CQRS.Queries.Triangles.GetTriangleAreaList;

public class GetTriangleAreaListQueryValidator : AbstractValidator<GetTriangleAreaListQuery>
{
    public GetTriangleAreaListQueryValidator()
    {
    }
}