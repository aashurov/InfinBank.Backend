using AutoMapper;
using InfinBank.Application.Common.Mappings;
using InfinBank.Application.CQRS.Commands.Circles.CreateCircleSquare;
using InfinBank.Application.CQRS.Commands.Rectangles.CreateRectangleSquare;
using InfinBank.Application.CQRS.Commands.Squares.CreateSquareArea;
using InfinBank.Application.CQRS.Commands.Squares.CreateSquarePerimeter;
using InfinBank.Application.CQRS.Commands.Triangles.CreateTrianglePerimeter;
using InfinBank.Application.CQRS.Commands.Triangles.UpdateTriangleArea;
using InfinBank.Application.CQRS.Commands.Triangles.UpdateTrianglePerimeter;

namespace InfinBank.WebApi.Models.Triangles;

/// <summary>
///Class UpdateTriangleAreaDto
/// </summary>
public class UpdateTriangleAreaDto : IMapWith<UpdateTriangleAreaCommand>
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
        profile.CreateMap<UpdateTriangleAreaDto, UpdateTriangleAreaCommand>()
            .ForMember(updateTriangleAreaCommand => updateTriangleAreaCommand.Id,
                options => options.MapFrom(updateTriangleAreaDto => updateTriangleAreaDto.Id))
            .ForMember(updateTriangleAreaCommand => updateTriangleAreaCommand.ASide,
                options => options.MapFrom(updateTriangleAreaDto => updateTriangleAreaDto.ASide))
            .ForMember(updateTriangleAreaCommand => updateTriangleAreaCommand.BSide,
                options => options.MapFrom(updateTriangleAreaDto => updateTriangleAreaDto.BSide))
            .ForMember(updateTriangleAreaCommand => updateTriangleAreaCommand.CSide,
                options => options.MapFrom(updateTriangleAreaDto => updateTriangleAreaDto.CSide));
    }
}