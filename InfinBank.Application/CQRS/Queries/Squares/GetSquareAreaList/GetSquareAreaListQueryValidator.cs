using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace InfinBank.Application.CQRS.Queries.Squares.GetSquareAreaList;

public class GetSquareAreaListQueryValidator : AbstractValidator<GetSquareAreaListQuery>
{
    public GetSquareAreaListQueryValidator()
    {
    }
}