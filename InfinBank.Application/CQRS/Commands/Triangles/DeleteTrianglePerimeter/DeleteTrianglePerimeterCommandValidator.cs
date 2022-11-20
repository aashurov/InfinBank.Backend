using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using InfinBank.Application.CQRS.Commands.Triangles.DeleteTriangleArea;

namespace InfinBank.Application.CQRS.Commands.Triangles.DeleteTrianglePerimeter;

public class DeleteTrianglePerimeterCommandValidator : AbstractValidator<DeleteTrianglePerimeterCommand>
{
    public DeleteTrianglePerimeterCommandValidator()
    {
        RuleFor(deleteTriangleAreaCommand => deleteTriangleAreaCommand.Id).GreaterThan(0);
    }
}