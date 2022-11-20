using AutoMapper;
using InfinBank.Application.Common.Mappings;
using InfinBank.Application.CQRS.Commands.Circles.CreateCircleSquare;
using InfinBank.Application.CQRS.Commands.Rectangles.CreateRectangleSquare;
using InfinBank.Application.CQRS.Commands.Squares.CreateSquareArea;

namespace InfinBank.WebApi.Models.Squares;

/// <summary>
///Class CreateSquareAreaDto
/// </summary>
public class CreateSquareAreaDto : IMapWith<CreateSquareAreaCommand>
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
        profile.CreateMap<CreateSquareAreaDto, CreateSquareAreaCommand>()
            .ForMember(createSquareAreaCommand => createSquareAreaCommand.Side,
                options => options.MapFrom(createSquareAreaDto => createSquareAreaDto.Side));
    }
}