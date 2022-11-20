using AutoMapper;
using InfinBank.Application.Common.Mappings;
using InfinBank.Domain.Entities.Circle;

namespace InfinBank.Application.CQRS.Queries.Circles.GetCircleCircumferenceList;

public class CircleCircumferenceLookupDto : IMapWith<CircleEntity>
{
    public int Id { get; set; }

    /// <summary>
    /// Circumference of circle
    /// </summary>
    public double Circumference { get; set; }

    /// <summary>
    /// Radius of circle
    /// </summary>
    public double Radius { get; set; }

    public DateTime DateCreated { get; set; }
    public DateTime? DateUpdated { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CircleEntity, CircleCircumferenceLookupDto>()
            .ForMember(circleCircumferenceLookupDto => circleCircumferenceLookupDto.Id, opt => opt.MapFrom(circleEntity => circleEntity.Id))

            .ForMember(circleCircumferenceLookupDto => circleCircumferenceLookupDto.Circumference, opt => opt.MapFrom(circleEntity => circleEntity.Circumference))
            .ForMember(circleCircumferenceLookupDto => circleCircumferenceLookupDto.Radius, opt => opt.MapFrom(circleEntity => circleEntity.Radius))

            .ForMember(circleCircumferenceLookupDto => circleCircumferenceLookupDto.DateCreated, opt => opt.MapFrom(circleEntity => circleEntity.DateCreated))
            .ForMember(circleCircumferenceLookupDto => circleCircumferenceLookupDto.DateUpdated, opt => opt.MapFrom(circleEntity => circleEntity.DateUpdated));
    }
}