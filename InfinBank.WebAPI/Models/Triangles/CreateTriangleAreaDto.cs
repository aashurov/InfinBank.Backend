using AutoMapper;
using InfinBank.Application.Common.Mappings;
using InfinBank.Application.CQRS.Commands.Circles.CreateCircleSquare;
using InfinBank.Application.CQRS.Commands.Rectangles.CreateRectangleSquare;
using InfinBank.Application.CQRS.Commands.Squares.CreateSquareArea;
using InfinBank.Application.CQRS.Commands.Triangles.CreateTriangleArea;

namespace InfinBank.WebApi.Models.Squares;

/// <summary>
///Class CreateSquareAreaDto
/// </summary>
public class CreateTriangleAreaDto : IMapWith<CreateTriangleAreaCommand>
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
        profile.CreateMap<CreateTriangleAreaDto, CreateTriangleAreaCommand>()
            .ForMember(createTriangleAreaCommand => createTriangleAreaCommand.ASide,
                options => options.MapFrom(createTriangleAreaDto => createTriangleAreaDto.ASide))
             .ForMember(createTriangleAreaCommand => createTriangleAreaCommand.BSide,
                options => options.MapFrom(createTriangleAreaDto => createTriangleAreaDto.BSide))
              .ForMember(createTriangleAreaCommand => createTriangleAreaCommand.CSide,
                options => options.MapFrom(createTriangleAreaDto => createTriangleAreaDto.CSide));
    }
}