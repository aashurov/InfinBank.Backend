using AutoMapper;
using InfinBank.Application.Common.Mappings;
using InfinBank.Application.CQRS.Commands.Circles.UpdateCircleSquare;
using InfinBank.Application.CQRS.Commands.Rectangles.UpdateRectangleSquare;

namespace InfinBank.WebApi.Models.Circles;

/// <summary>
/// UpdateCircleSquareDto
/// </summary>
public class UpdateRectangleSquareDto : IMapWith<UpdateRectangleSquareCommand>
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
        profile.CreateMap<UpdateRectangleSquareDto, UpdateRectangleSquareCommand>()
            .ForMember(updateRectangleSquareCommand => updateRectangleSquareCommand.Id,
                options => options.MapFrom(updateRectangleSquareDto => updateRectangleSquareDto.Id))
            .ForMember(updateRectangleSquareCommand => updateRectangleSquareCommand.Length,
                options => options.MapFrom(updateRectangleSquareDto => updateRectangleSquareDto.Length))
            .ForMember(updateRectangleSquareCommand => updateRectangleSquareCommand.Width,
                options => options.MapFrom(updateRectangleSquareDto => updateRectangleSquareDto.Width));
    }
}