using AutoMapper;
using InfinBank.Application.Common.Mappings;
using InfinBank.Application.CQRS.Commands.Circles.UpdateCircleCircumference;

namespace InfinBank.WebApi.Models.Circles;

/// <summary>
/// UpdateCircleSquareDto
/// </summary>
public class UpdateCircleCircumferenceDto : IMapWith<UpdateCircleCircumferenceCommand>
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
        profile.CreateMap<UpdateCircleCircumferenceDto, UpdateCircleCircumferenceCommand>()
            .ForMember(updateCircleCircumferenceCommand => updateCircleCircumferenceCommand.Id,
                options => options.MapFrom(updateCircleCircumferenceDto => updateCircleCircumferenceDto.Id))
            .ForMember(updateCircleCircumferenceCommand => updateCircleCircumferenceCommand.Radius,
                options => options.MapFrom(updateCircleCircumferenceDto => updateCircleCircumferenceDto.Radius));
    }
}