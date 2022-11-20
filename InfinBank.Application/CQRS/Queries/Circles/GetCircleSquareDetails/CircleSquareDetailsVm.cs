using AutoMapper;
using InfinBank.Application.Common.Mappings;
using InfinBank.Domain.Entities.Circle;

namespace InfinBank.Application.CQRS.Queries.Circles.GetCircleSquareDetails;

public class CircleSquareDetailsVm : IMapWith<CircleEntity>
{
    public int Id { get; set; }

    /// <summary>
    /// Square of circle
    /// </summary>
    public double Square { get; set; }

    /// <summary>
    /// Radius of circle
    /// </summary>
    public double Radius { get; set; }

    public DateTime DateCreated { get; set; }
    public DateTime? DateUpdated { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CircleEntity, CircleSquareDetailsVm>()
            .ForMember(circleSquareDetailsVm => circleSquareDetailsVm.Id, opt => opt.MapFrom(circleEntity => circleEntity.Id))
            .ForMember(circleSquareDetailsVm => circleSquareDetailsVm.Square, opt => opt.MapFrom(circleEntity => circleEntity.Square))
            .ForMember(circleSquareDetailsVm => circleSquareDetailsVm.DateCreated, opt => opt.MapFrom(circleEntity => circleEntity.DateCreated))
            .ForMember(circleSquareDetailsVm => circleSquareDetailsVm.DateUpdated, opt => opt.MapFrom(circleEntity => circleEntity.DateUpdated));
    }
}