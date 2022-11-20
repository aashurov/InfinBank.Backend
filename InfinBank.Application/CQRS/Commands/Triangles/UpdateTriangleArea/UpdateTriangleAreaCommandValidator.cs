using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace InfinBank.Application.CQRS.Commands.Triangles.UpdateTriangleArea;

public class UpdateTriangleAreaCommandValidator : AbstractValidator<UpdateTriangleAreaCommand>
{
    public UpdateTriangleAreaCommandValidator()
    {
        RuleFor(updateTriangleAreaCommand => updateTriangleAreaCommand.Id).GreaterThan(0);
        RuleFor(updateTriangleAreaCommand => updateTriangleAreaCommand.ASide).NotNull();
        RuleFor(updateTriangleAreaCommand => updateTriangleAreaCommand.BSide).NotNull();
        RuleFor(updateTriangleAreaCommand => updateTriangleAreaCommand.CSide).NotNull();
    }
}