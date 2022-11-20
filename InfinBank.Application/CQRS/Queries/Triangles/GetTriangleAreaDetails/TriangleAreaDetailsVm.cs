using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using InfinBank.Application.Common.Mappings;
using InfinBank.Domain.Entities.Triangle;

namespace InfinBank.Application.CQRS.Queries.Triangles.GetTriangleAreaDetails;

public class TriangleAreaDetailsVm : IMapWith<TriangleEntity>
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
        profile.CreateMap<TriangleEntity, TriangleAreaDetailsVm>()
            .ForMember(squareAreaDetailsVm => squareAreaDetailsVm.Id, opt => opt.MapFrom(triangleEntity => triangleEntity.Id))
            .ForMember(squareAreaDetailsVm => squareAreaDetailsVm.ASide, opt => opt.MapFrom(triangleEntity => triangleEntity.ASide))
            .ForMember(squareAreaDetailsVm => squareAreaDetailsVm.BSide, opt => opt.MapFrom(triangleEntity => triangleEntity.BSide))
            .ForMember(squareAreaDetailsVm => squareAreaDetailsVm.CSide, opt => opt.MapFrom(triangleEntity => triangleEntity.CSide))
            .ForMember(squareAreaDetailsVm => squareAreaDetailsVm.Square, opt => opt.MapFrom(triangleEntity => triangleEntity.Square))
            .ForMember(squareAreaDetailsVm => squareAreaDetailsVm.DateCreated, opt => opt.MapFrom(triangleEntity => triangleEntity.DateCreated))
            .ForMember(squareAreaDetailsVm => squareAreaDetailsVm.DateUpdated, opt => opt.MapFrom(triangleEntity => triangleEntity.DateUpdated));
    }
}
