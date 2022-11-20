using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using InfinBank.Application.Common.Mappings;
using InfinBank.Domain.Entities.Triangle;

namespace InfinBank.Application.CQRS.Queries.Triangles.GetTriangleAreaList;

public class TriangleAreaLookupDto : IMapWith<TriangleEntity>
{
    public int Id { get; set; }

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
    /// Area of square
    /// </summary>
    public double Square { get; set; }

    public DateTime DateCreated { get; set; }
    public DateTime? DateUpdated { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<TriangleEntity, TriangleAreaLookupDto>()
            .ForMember(triangleAreaLookupDto => triangleAreaLookupDto.Id, opt => opt.MapFrom(triangleEntity => triangleEntity.Id))

            .ForMember(triangleAreaLookupDto => triangleAreaLookupDto.ASide, opt => opt.MapFrom(triangleEntity => triangleEntity.ASide))
            .ForMember(triangleAreaLookupDto => triangleAreaLookupDto.BSide, opt => opt.MapFrom(triangleEntity => triangleEntity.BSide))
            .ForMember(triangleAreaLookupDto => triangleAreaLookupDto.CSide, opt => opt.MapFrom(triangleEntity => triangleEntity.CSide))
            .ForMember(triangleAreaLookupDto => triangleAreaLookupDto.Square, opt => opt.MapFrom(triangleEntity => triangleEntity.Square))

            .ForMember(triangleAreaLookupDto => triangleAreaLookupDto.DateCreated, opt => opt.MapFrom(triangleEntity => triangleEntity.DateCreated))
            .ForMember(triangleAreaLookupDto => triangleAreaLookupDto.DateUpdated, opt => opt.MapFrom(triangleEntity => triangleEntity.DateUpdated));
    }
}