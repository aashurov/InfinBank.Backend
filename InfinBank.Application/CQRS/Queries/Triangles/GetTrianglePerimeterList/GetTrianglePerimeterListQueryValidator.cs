using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
 
namespace InfinBank.Application.CQRS.Queries.Triangles.GetTrianglePerimeterList;

public class GetTrianglePerimeterListQueryValidator : AbstractValidator<GetTrianglePerimeterListQuery>
{
    public GetTrianglePerimeterListQueryValidator()
    {
    }
}