using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using InfinBank.Application.CQRS.Queries.Squares.GetSquarePerimeterList;

namespace InfinBank.Application.CQRS.Queries.Squares.GetSquarePerimeterList;

public class GetSquarePerimeterListQueryValidator : AbstractValidator<GetSquarePerimeterListQuery>
{
    public GetSquarePerimeterListQueryValidator()
    {
    }
}