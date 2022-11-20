using AutoMapper;
using InfinBank.Application.Common.Mappings;
using InfinBank.Application.CQRS.Commands.Circles.CreateCircleSquare;
using InfinBank.Application.CQRS.Commands.Rectangles.CreateRectangleSquare;
using InfinBank.Application.CQRS.Commands.Squares.CreateSquareArea;
using InfinBank.Application.CQRS.Commands.Squares.CreateSquarePerimeter;
using InfinBank.Application.CQRS.Commands.Triangles.CreateTrianglePerimeter;

namespace InfinBank.WebApi.Models.Triangles;

/// <summary>
///Class CreateSquarePerimeterDto
/// </summary>
public class CreateTrianglePerimeterDto : IMapWith<CreateTrianglePerimeterCommand>
{
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
        profile.CreateMap<CreateTrianglePerimeterDto, CreateTrianglePerimeterCommand>()
            .ForMember(createTrianglePerimeterCommand => createTrianglePerimeterCommand.ASide,
                options => options.MapFrom(createTrianglePerimeterDto => createTrianglePerimeterDto.ASide))
            .ForMember(createTrianglePerimeterCommand => createTrianglePerimeterCommand.BSide,
                options => options.MapFrom(createTrianglePerimeterDto => createTrianglePerimeterDto.BSide))
            .ForMember(createTrianglePerimeterCommand => createTrianglePerimeterCommand.CSide,
                options => options.MapFrom(createTrianglePerimeterDto => createTrianglePerimeterDto.CSide));
    }
}