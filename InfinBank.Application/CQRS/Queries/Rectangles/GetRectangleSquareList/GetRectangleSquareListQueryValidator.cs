using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace InfinBank.Application.CQRS.Queries.Rectangles.GetRectangleSquareList;

public class GetRectangleSquareListQueryValidator : AbstractValidator<GetRectangleSquareListQuery>
{
    public GetRectangleSquareListQueryValidator()
    {
    }
}
