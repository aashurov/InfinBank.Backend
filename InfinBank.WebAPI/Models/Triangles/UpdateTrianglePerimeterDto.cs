using AutoMapper;
using InfinBank.Application.Common.Mappings;
using InfinBank.Application.CQRS.Commands.Circles.CreateCircleSquare;
using InfinBank.Application.CQRS.Commands.Rectangles.CreateRectangleSquare;
using InfinBank.Application.CQRS.Commands.Squares.CreateSquareArea;
using InfinBank.Application.CQRS.Commands.Squares.CreateSquarePerimeter;
using InfinBank.Application.CQRS.Commands.Triangles.CreateTrianglePerimeter;
using InfinBank.Application.CQRS.Commands.Triangles.UpdateTrianglePerimeter;

namespace InfinBank.WebApi.Models.Triangles;

/// <summary>
///Class UpdateTrianglePerimeterDto
/// </summary>
public class UpdateTrianglePerimeterDto : IMapWith<UpdateTrianglePerimeterCommand>
{
    /// <summary>
    /// Id
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// A side of triangle
    /// </summary>
    public double ASide { get; set; }

    /// <summary>
    /// B side of triangle
    /// </summary>
    public double BSide { get; set; }

    /// <summary>
    /// C side of triangle
    /// </summary>
    public double CSide { get; set; }

    /// <summary>
    /// Mapping
    /// </summary>
    /// <param name="profile"></param>
    public void Mapping(Profile profile)
    {
        profile.CreateMap<UpdateTrianglePerimeterDto, UpdateTrianglePerimeterCommand>()
            .ForMember(updateTrianglePerimeterCommand => updateTrianglePerimeterCommand.Id,
                options => options.MapFrom(updateTrianglePerimeterDto => updateTrianglePerimeterDto.Id))
            .ForMember(updateTrianglePerimeterCommand => updateTrianglePerimeterCommand.ASide,
                options => options.MapFrom(updateTrianglePerimeterDto => updateTrianglePerimeterDto.ASide))
            .ForMember(updateTrianglePerimeterCommand => updateTrianglePerimeterCommand.BSide,
                options => options.MapFrom(updateTrianglePerimeterDto => updateTrianglePerimeterDto.BSide))
            .ForMember(updateTrianglePerimeterCommand => updateTrianglePerimeterCommand.CSide,
                options => options.MapFrom(updateTrianglePerimeterDto => updateTrianglePerimeterDto.CSide));
    }
}