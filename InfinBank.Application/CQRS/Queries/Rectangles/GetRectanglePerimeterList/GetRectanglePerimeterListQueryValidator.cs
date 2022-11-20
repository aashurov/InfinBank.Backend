using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace InfinBank.Application.CQRS.Queries.Rectangles.GetRectanglePerimeterList;

public class GetRectanglePerimeterListQueryValidator : AbstractValidator<GetRectanglePerimeterListQuery>
{
    public GetRectanglePerimeterListQueryValidator()
    {
    }
}
