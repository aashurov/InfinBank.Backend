using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using InfinBank.Application.Common.Mappings;
using InfinBank.Domain.Entities.Triangle;

namespace InfinBank.Application.CQRS.Queries.Triangles.GetTrianglePerimeterList;

public class TrianglePerimeterLookupDto : IMapWith<TriangleEntity>
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
    /// Perimeter of square
    /// </summary>
    public double Perimeter { get; set; }

    public DateTime DateCreated { get; set; }
    public DateTime? DateUpdated { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<TriangleEntity, TrianglePerimeterLookupDto>()
            .ForMember(trianglePerimeterLookupDto => trianglePerimeterLookupDto.Id, opt => opt.MapFrom(triangleEntity => triangleEntity.Id))
                                                         
            .ForMember(trianglePerimeterLookupDto => trianglePerimeterLookupDto.ASide, opt => opt.MapFrom(triangleEntity => triangleEntity.ASide))
            .ForMember(trianglePerimeterLookupDto => trianglePerimeterLookupDto.BSide, opt => opt.MapFrom(triangleEntity => triangleEntity.BSide))
            .ForMember(trianglePerimeterLookupDto => trianglePerimeterLookupDto.CSide, opt => opt.MapFrom(triangleEntity => triangleEntity.CSide))
            .ForMember(trianglePerimeterLookupDto => trianglePerimeterLookupDto.Perimeter, opt => opt.MapFrom(triangleEntity => triangleEntity.Perimeter))
                                                         
            .ForMember(trianglePerimeterLookupDto => trianglePerimeterLookupDto.DateCreated, opt => opt.MapFrom(triangleEntity => triangleEntity.DateCreated))
            .ForMember(trianglePerimeterLookupDto => trianglePerimeterLookupDto.DateUpdated, opt => opt.MapFrom(triangleEntity => triangleEntity.DateUpdated));
    }
}