using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace InfinBank.Application.CQRS.Queries.Squares.GetSquareAreaDetails;

public class GetSquareAreaDetailsQueryValidator : AbstractValidator<GetSquareAreaDetailsQuery>
{
    public GetSquareAreaDetailsQueryValidator()
    {
        RuleFor(getSquareAreaDetailsQuery => getSquareAreaDetailsQuery.Id).GreaterThan(0);
    }
}
