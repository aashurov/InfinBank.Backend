using AutoMapper;
using InfinBank.Application.Common.Mappings;
using InfinBank.Application.CQRS.Commands.Circles.CreateCircleSquare;
using InfinBank.Application.CQRS.Commands.Rectangles.CreateRectangleSquare;
using InfinBank.Application.CQRS.Commands.Squares.CreateSquareArea;
using InfinBank.Application.CQRS.Commands.Squares.CreateSquarePerimeter;

namespace InfinBank.WebApi.Models.Squares;

/// <summary>
///Class CreateSquarePerimeterDto
/// </summary>
public class CreateSquarePerimeterDto : IMapWith<CreateSquarePerimeterCommand>
{
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
        profile.CreateMap<CreateSquarePerimeterDto, CreateSquarePerimeterCommand>()
            .ForMember(createSquareAreaCommand => createSquareAreaCommand.Side,
                options => options.MapFrom(createSquarePerimeterDto => createSquarePerimeterDto.Side));
    }
}