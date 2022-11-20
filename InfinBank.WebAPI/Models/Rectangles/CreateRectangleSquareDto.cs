using AutoMapper;
using InfinBank.Application.Common.Mappings;
using InfinBank.Application.CQRS.Commands.Circles.CreateCircleSquare;
using InfinBank.Application.CQRS.Commands.Rectangles.CreateRectanglePerimeter;
using InfinBank.Application.CQRS.Commands.Rectangles.CreateRectangleSquare;

namespace InfinBank.WebApi.Models.Circles;

/// <summary>
///Class CreateCircleSquareDto
/// </summary>
public class CreateRectangleSquareDto : IMapWith<CreateRectangleSquareCommand>
{
    /// <summary>
    /// Length of rectangle
    /// </summary>
    public double Length { get; set; }

    /// <summary>
    /// Width of rectangle
    /// </summary>
    public double Width { get; set; }

    /// <summary>
    /// Mapping
    /// </summary>
    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateRectangleSquareDto, CreateRectangleSquareCommand>()
            .ForMember(createRectangleSquareCommand => createRectangleSquareCommand.Length,
                options => options.MapFrom(createRectangleSquareDto => createRectangleSquareDto.Length))
            .ForMember(createRectangleSquareCommand => createRectangleSquareCommand.Width,
                options => options.MapFrom(createRectangleSquareDto => createRectangleSquareDto.Width));
    }
}