using AutoMapper;
using InfinBank.Application.Common.Mappings;
using InfinBank.Application.CQRS.Commands.Circles.CreateCircleSquare;
using InfinBank.Application.CQRS.Commands.Rectangles.CreateRectangleSquare;
using InfinBank.Application.CQRS.Commands.Squares.CreateSquareArea;
using InfinBank.Application.CQRS.Commands.Squares.UpdateSquareArea;

namespace InfinBank.WebApi.Models.Squares;

/// <summary>
/// Class UpdateSquareAreaDto
/// </summary>
public class UpdateSquareAreaDto : IMapWith<UpdateSquareAreaCommand>
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
        profile.CreateMap<UpdateSquareAreaDto, UpdateSquareAreaCommand>()
            .ForMember(updateSquareAreaCommand => updateSquareAreaCommand.Id,
                options => options.MapFrom(updateSquareAreaDto => updateSquareAreaDto.Id))
            .ForMember(updateSquareAreaCommand => updateSquareAreaCommand.Side,
                options => options.MapFrom(updateSquareAreaDto => updateSquareAreaDto.Side));
    }
}