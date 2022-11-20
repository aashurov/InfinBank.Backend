using AutoMapper;
using InfinBank.Application.Common.Mappings;
using InfinBank.Application.CQRS.Commands.Circles.CreateCircleCircumference;
using System.ComponentModel.DataAnnotations;

namespace InfinBank.WebApi.Models.Circles;

/// <summary>
/// CreateCircleCircumferenceDto
/// </summary>
public class CreateCircleCircumferenceDto : IMapWith<CreateCircleCircumferenceCommand>
{
    /// <summary>
    /// Radius
    /// </summary>
    [Required]
    public double Radius { get; set; }

    /// <summary>
    /// Mapping
    /// </summary>
    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateCircleCircumferenceDto, CreateCircleCircumferenceCommand>()
            .ForMember(createCircleCircumferenceCommand => createCircleCircumferenceCommand.Radius,
                options => options.MapFrom(createCircleCircumferenceDto => createCircleCircumferenceDto.Radius));
    }
}