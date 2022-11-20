using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace InfinBank.Application.CQRS.Commands.Triangles.UpdateTrianglePerimeter;

public class UpdateTrianglePerimeterCommandValidator : AbstractValidator<UpdateTrianglePerimeterCommand>
{
    public UpdateTrianglePerimeterCommandValidator()
    {
        RuleFor(updateTrianglePerimeterCommand => updateTrianglePerimeterCommand.Id).GreaterThan(0);
        RuleFor(updateTrianglePerimeterCommand => updateTrianglePerimeterCommand.ASide).NotNull();
        RuleFor(updateTrianglePerimeterCommand => updateTrianglePerimeterCommand.BSide).NotNull();
        RuleFor(updateTrianglePerimeterCommand => updateTrianglePerimeterCommand.CSide).NotNull();
    }
}
