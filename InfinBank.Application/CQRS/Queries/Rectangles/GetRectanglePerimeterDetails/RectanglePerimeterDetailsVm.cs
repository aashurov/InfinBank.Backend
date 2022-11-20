using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using InfinBank.Application.Common.Mappings;
using InfinBank.Domain.Entities.Rectangle;

namespace InfinBank.Application.CQRS.Queries.Rectangles.GetRectanglePerimeterDetails;

public class RectanglePerimeterDetailsVm : IMapWith<RectangleEntity>
{
    public int Id { get; set; }

    /// <summary>
    /// Length of rectangle
    /// </summary>
    public double Length { get; set; }

    /// <summary>
    /// Width of rectangle
    /// </summary>
    public double Width { get; set; }

    /// <summary>
    /// Perimeter of rectangle
    /// </summary>
    public double Perimeter { get; set; }

    public DateTime DateCreated { get; set; }
    public DateTime? DateUpdated { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<RectangleEntity, RectanglePerimeterDetailsVm>()
            .ForMember(rectanglePerimeterDetailsVm => rectanglePerimeterDetailsVm.Id, opt => opt.MapFrom(rectangleEntity => rectangleEntity.Id))
            .ForMember(rectanglePerimeterDetailsVm => rectanglePerimeterDetailsVm.Length, opt => opt.MapFrom(rectangleEntity => rectangleEntity.Length))
            .ForMember(rectanglePerimeterDetailsVm => rectanglePerimeterDetailsVm.Width, opt => opt.MapFrom(rectangleEntity => rectangleEntity.Width))
            .ForMember(rectanglePerimeterDetailsVm => rectanglePerimeterDetailsVm.Perimeter, opt => opt.MapFrom(rectangleEntity => rectangleEntity.Perimeter))
            .ForMember(rectanglePerimeterDetailsVm => rectanglePerimeterDetailsVm.DateCreated, opt => opt.MapFrom(rectangleEntity => rectangleEntity.DateCreated))
            .ForMember(rectanglePerimeterDetailsVm => rectanglePerimeterDetailsVm.DateUpdated, opt => opt.MapFrom(rectangleEntity => rectangleEntity.DateUpdated));
    }
}