using FluentValidation;

namespace InfinBank.Application.CQRS.Commands.Triangles.CreateTriangleArea;

public class CreateTriangleAreaCommandValidator : AbstractValidator<CreateTriangleAreaCommand>
{
    public CreateTriangleAreaCommandValidator()
    {
        RuleFor(createTriangleAreaCommand => createTriangleAreaCommand.ASide).NotNull();
        RuleFor(createTriangleAreaCommand => createTriangleAreaCommand.BSide).NotNull();
        RuleFor(createTriangleAreaCommand => createTriangleAreaCommand.CSide).NotNull();
    }
}