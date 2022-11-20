using AutoMapper;
using InfinBank.Application.Common.Mappings;
using InfinBank.Application.CQRS.Commands.Circles.CreateCircleSquare;
using InfinBank.Application.CQRS.Commands.Rectangles.CreateRectangleSquare;
using InfinBank.Application.CQRS.Commands.Squares.CreateSquareArea;
using InfinBank.Application.CQRS.Commands.Squares.CreateSquarePerimeter;
using InfinBank.Application.CQRS.Commands.Squares.UpdateSquarePerimeter;

namespace InfinBank.WebApi.Models.Circles;

/// <summary>
///Class UpdateSquarePerimeterDto
/// </summary>
public class UpdateSquarePerimeterDto : IMapWith<UpdateSquarePerimeterCommand>
{

    /// <summary>
    /// Id
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Side of square
    /// </summary>
    public double Side { get; set; }


    /// <summary>
    /// Mapping
    /// </summary>
    /// <param name="profile"></param>
    public void Mapping(Profile profile)
    {
        profile.CreateMap<UpdateSquarePerimeterDto, UpdateSquarePerimeterCommand>()
            .ForMember(updateSquarePerimeterCommand => updateSquarePerimeterCommand.Id,
                options => options.MapFrom(updateSquarePerimeterDto => updateSquarePerimeterDto.Id))
            .ForMember(updateSquarePerimeterCommand => updateSquarePerimeterCommand.Side,
                options => options.MapFrom(updateSquarePerimeterDto => updateSquarePerimeterDto.Side));
    }
}