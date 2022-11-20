using AutoMapper;
using InfinBank.Application.Common.Mappings;
using InfinBank.Application.CQRS.Commands.Circles.UpdateCircleSquare;

namespace InfinBank.WebApi.Models.Circles;

/// <summary>
/// UpdateCircleSquareDto
/// </summary>
public class UpdateCircleSquareDto : IMapWith<UpdateCircleSquareCommand>
{
    /// <summary>
    /// Id
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Radius of circle
    /// </summary>
    public double Radius { get; set; }

    /// <summary>
    /// Mapping
    /// </summary>
    /// <param name="profile"></param>
    public void Mapping(Profile profile)
    {
        profile.CreateMap<UpdateCircleSquareDto, UpdateCircleSquareCommand>()
            .ForMember(updateCircleSquareCommand => updateCircleSquareCommand.Id,
                options => options.MapFrom(updateCircleSquareDto => updateCircleSquareDto.Id))
            .ForMember(updateCircleSquareCommand => updateCircleSquareCommand.Radius,
                options => options.MapFrom(updateCircleSquareDto => updateCircleSquareDto.Radius));
    }
}