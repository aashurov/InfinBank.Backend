using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace InfinBank.Application.CQRS.Commands.Triangles.DeleteTriangleArea;

public class DeleteTriangleAreaCommandValidator : AbstractValidator<DeleteTriangleAreaCommand>
{
    public DeleteTriangleAreaCommandValidator()
    {
        RuleFor(deleteTriangleAreaCommand => deleteTriangleAreaCommand.Id).GreaterThan(0);
    }
}