using AutoMapper;
using InfinBank.Application.Common.Mappings;
using InfinBank.Application.CQRS.Commands.Circles.CreateCircleCircumference;
using InfinBank.Application.CQRS.Commands.Rectangles.CreateRectanglePerimeter;
using System.ComponentModel.DataAnnotations;

namespace InfinBank.WebApi.Models.Circles;

/// <summary>
/// CreateCircleCircumferenceDto
/// </summary>
public class CreateRectanglePerimeterDto : IMapWith<CreateRectanglePerimeterCommand>
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
        profile.CreateMap<CreateRectanglePerimeterDto, CreateRectanglePerimeterCommand>()
            .ForMember(createCircleCircumferenceCommand => createCircleCircumferenceCommand.Length,
                options => options.MapFrom(createRectanglePerimeterDto => createRectanglePerimeterDto.Length))
            .ForMember(createCircleCircumferenceCommand => createCircleCircumferenceCommand.Width,
                options => options.MapFrom(createRectanglePerimeterDto => createRectanglePerimeterDto.Width));
    }
}