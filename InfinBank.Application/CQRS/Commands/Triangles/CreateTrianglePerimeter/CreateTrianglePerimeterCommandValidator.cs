using FluentValidation;

namespace InfinBank.Application.CQRS.Commands.Triangles.CreateTrianglePerimeter;

public class CreateTrianglePerimeterCommandValidator : AbstractValidator<CreateTrianglePerimeterCommand>
{
    public CreateTrianglePerimeterCommandValidator()
    {
        RuleFor(createTrianglePerimeterCommand => createTrianglePerimeterCommand.ASide).NotNull();
        RuleFor(createTrianglePerimeterCommand => createTrianglePerimeterCommand.BSide).NotNull();
        RuleFor(createTrianglePerimeterCommand => createTrianglePerimeterCommand.CSide).NotNull();
    }
}