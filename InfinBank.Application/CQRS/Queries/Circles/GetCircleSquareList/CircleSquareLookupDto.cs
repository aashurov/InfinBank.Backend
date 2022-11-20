using AutoMapper;
using InfinBank.Application.Common.Mappings;
using InfinBank.Domain.Entities.Circle;

namespace InfinBank.Application.CQRS.Queries.Circles.GetCircleSquareList;

public class CircleSquareLookupDto : IMapWith<CircleEntity>
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
        profile.CreateMap<CircleEntity, CircleSquareLookupDto>()
            .ForMember(circleSquareLookupDto => circleSquareLookupDto.Id, opt => opt.MapFrom(circleEntity => circleEntity.Id))

            .ForMember(circleSquareLookupDto => circleSquareLookupDto.Square, opt => opt.MapFrom(circleEntity => circleEntity.Square))
            .ForMember(circleSquareLookupDto => circleSquareLookupDto.Radius, opt => opt.MapFrom(circleEntity => circleEntity.Radius))

            .ForMember(circleSquareLookupDto => circleSquareLookupDto.DateCreated, opt => opt.MapFrom(circleEntity => circleEntity.DateCreated))
            .ForMember(circleSquareLookupDto => circleSquareLookupDto.DateUpdated, opt => opt.MapFrom(circleEntity => circleEntity.DateUpdated));
    }
}