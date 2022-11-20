using AutoMapper;
using InfinBank.Application.Common.Mappings;
using InfinBank.Application.CQRS.Commands.Circles.UpdateCircleCircumference;
using InfinBank.Application.CQRS.Commands.Rectangles.UpdateRectanglePerimeter;

namespace InfinBank.WebApi.Models.Circles;

/// <summary>
/// UpdateCircleSquareDto
/// </summary>
public class UpdateRectanglePerimeterDto : IMapWith<UpdateRectanglePerimeterCommand>
{
    /// <summary>
    /// Id
    /// </summary>
    public int Id { get; set; }

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
    /// <param name="profile"></param>
    public void Mapping(Profile profile)
    {
        profile.CreateMap<UpdateRectanglePerimeterDto, UpdateRectanglePerimeterCommand>()
            .ForMember(updateRectanglePerimeterCommand => updateRectanglePerimeterCommand.Id,
                options => options.MapFrom(updateRectanglePerimeterDto => updateRectanglePerimeterDto.Id))
            .ForMember(updateRectanglePerimeterCommand => updateRectanglePerimeterCommand.Length,
                options => options.MapFrom(updateRectanglePerimeterDto => updateRectanglePerimeterDto.Length))
            .ForMember(updateRectanglePerimeterCommand => updateRectanglePerimeterCommand.Width,
                options => options.MapFrom(updateRectanglePerimeterDto => updateRectanglePerimeterDto.Width));
    }
}