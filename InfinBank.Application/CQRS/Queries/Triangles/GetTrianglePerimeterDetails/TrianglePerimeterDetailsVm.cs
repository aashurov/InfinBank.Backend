using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using InfinBank.Application.Common.Mappings;
using InfinBank.Application.CQRS.Queries.Squares.GetSquarePerimeterDetails;
using InfinBank.Domain.Entities.Triangle;

namespace InfinBank.Application.CQRS.Queries.Triangles.GetTrianglePerimeterDetails;

public class TrianglePerimeterDetailsVm : IMapWith<TriangleEntity>
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
        profile.CreateMap<TriangleEntity, TrianglePerimeterDetailsVm>()
            .ForMember(squarePerimeterDetailsVm => squarePerimeterDetailsVm.Id, opt => opt.MapFrom(triangleEntity => triangleEntity.Id))
            .ForMember(squarePerimeterDetailsVm => squarePerimeterDetailsVm.ASide, opt => opt.MapFrom(triangleEntity => triangleEntity.ASide))
            .ForMember(squarePerimeterDetailsVm => squarePerimeterDetailsVm.BSide, opt => opt.MapFrom(triangleEntity => triangleEntity.BSide))
            .ForMember(squarePerimeterDetailsVm => squarePerimeterDetailsVm.CSide, opt => opt.MapFrom(triangleEntity => triangleEntity.CSide))
            .ForMember(squarePerimeterDetailsVm => squarePerimeterDetailsVm.Perimeter, opt => opt.MapFrom(triangleEntity => triangleEntity.Perimeter))
            .ForMember(squarePerimeterDetailsVm => squarePerimeterDetailsVm.DateCreated, opt => opt.MapFrom(triangleEntity => triangleEntity.DateCreated))
            .ForMember(squarePerimeterDetailsVm => squarePerimeterDetailsVm.DateUpdated, opt => opt.MapFrom(triangleEntity => triangleEntity.DateUpdated));
    }
}
