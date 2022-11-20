using AutoMapper;
using InfinBank.Application.Common.Mappings;
using InfinBank.Domain.Entities.Circle;

namespace InfinBank.Application.CQRS.Queries.Circles.GetlCircleCircumferenceDetails;

public class CircleCircumferenceDetailsVm : IMapWith<CircleEntity>
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
        profile.CreateMap<CircleEntity, CircleCircumferenceDetailsVm>()
            .ForMember(circleCircumferenceDetailsVm => circleCircumferenceDetailsVm.Id, opt => opt.MapFrom(circleEntity => circleEntity.Id))
            .ForMember(circleCircumferenceDetailsVm => circleCircumferenceDetailsVm.Circumference, opt => opt.MapFrom(circleEntity => circleEntity.Circumference))
            .ForMember(circleCircumferenceDetailsVm => circleCircumferenceDetailsVm.DateCreated, opt => opt.MapFrom(circleEntity => circleEntity.DateCreated))
            .ForMember(circleCircumferenceDetailsVm => circleCircumferenceDetailsVm.DateUpdated, opt => opt.MapFrom(circleEntity => circleEntity.DateUpdated));
    }
}