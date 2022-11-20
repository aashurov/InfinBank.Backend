using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
 
namespace InfinBank.Application.CQRS.Queries.Squares.GetSquarePerimeterDetails;

public class GetSquarePerimeterDetailsQueryValidator : AbstractValidator<GetSquarePerimeterDetailsQuery>
{
    public GetSquarePerimeterDetailsQueryValidator()
    {
        RuleFor(getSquarePerimeterDetailsQuery => getSquarePerimeterDetailsQuery.Id).GreaterThan(0);
    }
}
